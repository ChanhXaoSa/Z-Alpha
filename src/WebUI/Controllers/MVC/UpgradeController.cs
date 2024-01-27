using Microsoft.AspNetCore.Mvc;
using ZAlpha.Infrastructure.Library;
using ZAlpha.Infrastructure.Model;

namespace WebUI.Controllers.MVC;
public class UpgradeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<UpgradeController> _logger;

    public UpgradeController(IConfiguration configuration, IHttpContextAccessor contextAccessor, ILogger<UpgradeController> logger)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(bool hello)
    {
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
        vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
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
