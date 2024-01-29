using MailKit.Search;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Pack.Queries.GetPack;
using ZAlpha.Application.PackDetail.Commands.CreatePackDetail;
using ZAlpha.Application.Transaction.Commands.CreateTransaction;
using ZAlpha.Application.Transaction.Commands.UpdateTransaction;
using ZAlpha.Infrastructure.Library;
using ZAlpha.Infrastructure.Model;

namespace WebUI.Controllers.MVC;
public class UpgradeController : ControllerBaseMVC
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<UpgradeController> _logger;
    private readonly IIdentityService _identityService;

    public UpgradeController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ILogger<UpgradeController> logger, IIdentityService identityService)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
        _logger = logger;
        _identityService = identityService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string Method)
    {

        if (User.Identity.Name?.Length <= 0)
        {
            return Redirect("/login");
        }
        else
        {
            var userLogined = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var transactionId = await Mediator.Send(new CreateTransactionsCommands()
            {
                UserAccountId = userLogined.Id,
                PaymentMethodId = Guid.Parse("94422c85-1d58-4f47-b5cb-a2794e757268"),
                Balance = 0,
                Description = "VNPAY",
                Money = 10000,
                Status = 0,
                TransactionFee = 0,
            });

            //Get Config Info
            string vnp_Returnurl = _configuration["VnPay:vnp_Returnurl"]; //URL nhan ket qua tra ve 
            string vnp_Url = _configuration["VnPay:vnp_Url"]; //URL thanh toan cua VNPAY 
            string vnp_TmnCode = _configuration["VnPay:vnp_TmnCode"]; //Ma định danh merchant kết nối (Terminal Id)
            string vnp_HashSecret = _configuration["VnPay:vnp_HashSecret"]; //Secret Key

            //Get payment input
            OrderInfo order = new OrderInfo();
            order.OrderId = DateTime.Now.Ticks; // Giả lập mã giao dịch hệ thống merchant gửi sang VNPAY
            order.Amount = 10000; // Giả lập số tiền thanh toán hệ thống merchant gửi sang VNPAY 1,000 VND
            order.Status = "0"; //0: Trạng thái thanh toán "chờ thanh toán" hoặc "Pending" khởi tạo giao dịch chưa có IPN
            order.CreatedDate = DateTime.Now;
            //Save order to db

            //Build URL for VNPAY
            VnPayLibrary vnpay = new VnPayLibrary();

            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", vnp_TmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000

            bool bankcode_Vnpayqr = false;
            bool bankcode_Vnbank = false;
            bool bankcode_Intcard = false;

            if (bankcode_Vnpayqr == true)
            {
                vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
            }
            else if (bankcode_Vnbank == true)
            {
                vnpay.AddRequestData("vnp_BankCode", "VNBANK");
            }
            else if (bankcode_Intcard == true)
            {
                vnpay.AddRequestData("vnp_BankCode", "INTCARD");
            }

            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(_contextAccessor));

            //if (locale_Vn.Checked == true)
            //{
            vnpay.AddRequestData("vnp_Locale", "vn");
            //}
            //else if (locale_En.Checked == true)
            //{
            //    vnpay.AddRequestData("vnp_Locale", "en");
            //}
            //vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
            vnpay.AddRequestData("vnp_OrderInfo", transactionId.ToString());
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other

            vnpay.AddRequestData("vnp_ReturnUrl", vnp_Returnurl);
            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày

            //Add Params of 2.1.0 Version
            //Billing

            string paymentUrl = vnpay.CreateRequestUrl(vnp_Url, vnp_HashSecret);
            _logger.LogInformation("VNPAY URL: {0}", paymentUrl);
            return Redirect(paymentUrl);
        }
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet]
    public async Task<IActionResult> Result(long vnp_Amount = 0, string vnp_BankCode = "", string vnp_BankTranNo = "", string vnp_CardType = "",
        string vnp_OrderInfo = "", string vnp_PayDate = "", string vnp_ResponseCode = "", string vnp_TmnCode = "", long vnp_TransactionNo = 0,
        string vnp_TransactionStatus = "", long vnp_TxnRef = 0, string vnp_SecureHash = "")
    {
        if (User.Identity.Name?.Length <= 0)
        {
            return Redirect("/login");
        }
        else
        {
            var userLogined = await _identityService.GetUserByNameAsync(User.Identity.Name);
            string vnp_HashSecret = _configuration["VnPay:vnp_HashSecret"]; //Secret Key
            VnPayLibrary vnpay = new VnPayLibrary();
            var vnpayData = Request.Query;
            foreach (var param in vnpayData)
            {
                string paramName = param.Key;
                string paramValue = param.Value;

                //get all querystring data
                if (!string.IsNullOrEmpty(paramName) && paramName.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(paramName, paramValue);
                }
            }
            bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash.Trim(), vnp_HashSecret);
            if (checkSignature)
            {
                if (vnp_ResponseCode == "00" && vnp_TransactionStatus == "00")
                {
                    ViewBag.ResultText = "Giao dịch được thực hiện thành công, cảm ơn quý khách đã xử dụng dịch vụ";
                    var transactionId = await Mediator.Send(new UpdateTransactionsCommands()
                    {
                        Id = Guid.Parse(vnp_OrderInfo),
                        Status = ZAlpha.Domain.Enums.TransactionStatus.COMPLETED,
                    });
                    var packs = Mediator.Send(new GetAllPackQueries());
                    var packChosen = packs.Result.FirstOrDefault(r => r.Id == Guid.Parse("e609e43f-b6ad-468e-91d1-785b282d345b"));
                    var packDetailNew = await Mediator.Send(new CreatePackDetailsCommands()
                    {
                        UserAccountId = userLogined.Id,
                        PackId = packChosen.Id,
                        StartDay = DateTime.Now,
                        EndDay = DateTime.Now.AddDays(30),
                    });
                }
                else
                {
                    ViewBag.ResultText = "Có lỗi xảy ra trong quá trình xử lý. Mã lỗi: " + vnp_ResponseCode;
                    var transactionId = await Mediator.Send(new UpdateTransactionsCommands()
                    {
                        Id = Guid.Parse(vnp_OrderInfo),
                        Status = ZAlpha.Domain.Enums.TransactionStatus.CANCELED,
                    });
                }
                ViewBag.displayTmnCode = "Mã Website (Terminal ID):" + vnp_TmnCode;
                ViewBag.displayTxnRef = "Mã giao dịch thanh toán:" + vnp_TxnRef.ToString();
                ViewBag.displayVnpayTranNo = "Mã giao dịch tại VNPAY:" + vnp_TransactionNo.ToString();
                ViewBag.displayAmount = "Số tiền thanh toán (VND):" + (vnp_Amount / 100).ToString();
                ViewBag.displayBankCode = "Ngân hàng thanh toán:" + vnp_BankCode;
            }
            else
            {
                ViewBag.ResultText = "Có lỗi xảy ra trong quá trình xử lý";
                var transactionId = await Mediator.Send(new UpdateTransactionsCommands()
                {
                    Id = Guid.Parse(vnp_OrderInfo),
                    Status = ZAlpha.Domain.Enums.TransactionStatus.FAILED,
                });
            }
            return View();
        }
    }
}
