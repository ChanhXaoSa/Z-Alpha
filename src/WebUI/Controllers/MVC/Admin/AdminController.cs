using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.Comment.Commands.DeleteComment;
using ZAlpha.Application.Comment.Commands.UpdateComment;
using ZAlpha.Application.Comment.Queries.GetAllComment;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.Common.Models;
using ZAlpha.Application.CustomerAccount.Queries.GetAllCustomerAccount;
using ZAlpha.Application.ManagerAccount.Queries.GetAllManagerAccount;
using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.PsychologistAccount.Queries.GetAllPsychologistAccount;
using ZAlpha.Application.Tag.Queries.GetTag;
using ZAlpha.Domain.Identity;

namespace WebUI.Controllers.MVC.Admin;
public class AdminController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly UserManager<UserAccount> _userManager;
    private readonly SignInManager<UserAccount> _signInManager;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public AdminController(IIdentityService identityService, UserManager<UserAccount> userManager, SignInManager<UserAccount> signInManager, IWebHostEnvironment hostingEnvironment)
    {
        _identityService = identityService;
        _userManager = userManager;
        _signInManager = signInManager;
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index()
    {
        return View("./AdminHome/Index");
    }

    public IActionResult Index2()
    {
        return View("./AdminHome/Index2");
    }

    public IActionResult ChartAmchart()
    {
        return View("./Chart/ChartAmchart");
    }

    public IActionResult ChartChartist()
    {
        return View("./Chart/ChartChartist");
    }

    public IActionResult ChartChartjs()
    {
        return View("./Chart/ChartChartjs");
    }

    public IActionResult ChartEchart()
    {
        return View("./Chart/ChartEchart");
    }

    public IActionResult ChartFlot()
    {
        return View("./Chart/ChartFlot");
    }

    public IActionResult ChartMorris()
    {
        return View("./Chart/ChartMorris");
    }

    public IActionResult ChartPeity()
    {
        return View("./Chart/ChartPeity");
    }

    public IActionResult ChartSparkline()
    {
        return View("./Chart/ChartSparkline");
    }

    public IActionResult EmailCompose()
    {
        return View("./Email/EmailCompose");
    }

    public IActionResult EmailInbox()
    {
        return View("./Email/EmailInbox");
    }

    public IActionResult EmailRead()
    {
        return View("./Email/EmailRead");
    }

    public IActionResult FormBasic()
    {
        return View("./Form/FormBasic");
    }

    public IActionResult FormDropzone()
    {
        return View("./Form/FormDropzone");
    }

    public IActionResult FormEditor()
    {
        return View("./Form/FormEditor");
    }

    public IActionResult FormLayout()
    {
        return View("./Form/FormLayout");
    }

    public IActionResult FormValidation()
    {
        return View("./Form/FormValidation");
    }

    public IActionResult LayoutBlank()
    {
        return View("./Layout/LayoutBlank");
    }

    public IActionResult LayoutBoxed()
    {
        return View("./Layout/LayoutBoxed");
    }

    public IActionResult LayoutFixHeader()
    {
        return View("./Layout/LayoutFixHeader");
    }

    public IActionResult LayoutFixSidebar()
    {
        return View("./Layout/LayoutFixSidebar");
    }

    public IActionResult MapGoogle()
    {
        return View("./Map/MapGoogle");
    }

    public IActionResult MapVector()
    {
        return View("./Map/MapVector");
    }

    public IActionResult PageError400()
    {
        return View("./PageError/PageError400");
    }

    public IActionResult PageError403()
    {
        return View("./PageError/PageError403");
    }

    public IActionResult PageError404()
    {
        return View("./PageError/PageError404");
    }

    public IActionResult PageError500()
    {
        return View("./PageError/PageError500");
    }

    public IActionResult PageError503()
    {
        return View("./PageError/PageError503");
    }

    public IActionResult TableBootstrap()
    {
        return View("./Table/TableBootstrap");
    }

    public IActionResult TableDatatable()
    {
        return View("./Table/TableDatatable");
    }

    public IActionResult UcCalender()
    {
        return View("./UC/UcCalender");
    }

    public IActionResult UcDatamap()
    {
        return View("./UC/UcDatamap");
    }

    public IActionResult UcNestedable()
    {
        return View("./UC/UcNestedable");
    }

    public IActionResult UcSweetalert()
    {
        return View("./UC/UcSweetalert");
    }

    public IActionResult UcToastr()
    {
        return View("./UC/UcToastr");
    }

    public IActionResult UcWeather()
    {
        return View("./UC/UcWeather");
    }

    public IActionResult UiAlert()
    {
        return View("./UI/UiAlert");
    }

    public IActionResult UiButton()
    {
        return View("./UI/UiButton");
    }

    public IActionResult UiDropdown()
    {
        return View("./UI/UiDropdown");
    }

    public IActionResult UiProgressbar()
    {
        return View("./UI/UiProgressbar");
    }

    public IActionResult UiTab()
    {
        return View("./UI/UiTab");
    }

    public IActionResult UiTypography()
    {
        return View("./UI/UiTypography");
    }

    public IActionResult UiTypographt()
    {
        return View("./UI/UiTypographt");
    }

    public IActionResult AppProfile()
    {
        return View("./Admin/AppProfile");
    }

    // Customer DataTable
    public async Task<IActionResult> CustomerDatatable()
    {
        try
        {
            var result = Mediator.Send(new GetCustomerAccountRequest() { Page = 1, Size = 1000 }).Result;
            return View("./ManageCustomer/CustomerDatatable", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // Psychology DataTable
    public async Task<IActionResult> PsychologistDatatable()
    {
        try
        {
            var result = Mediator.Send(new GetAllPsychologistAccountQueries() { Page = 1, Size = 1000 }).Result;
            return View("./ManagePsychologist/PsychologistDatatable", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // Manager DataTable
    public async Task<IActionResult> ManagerDatatable()
    {
        try
        {
            var result = Mediator.Send(new GetManagerAccountQueries() { Page = 1, Size = 1000 }).Result;
            return View("./ManageManager/ManagerDatatable", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // Post DataTable
    public async Task<IActionResult> PostDatatable()
    {
        try
        {
            var result = Mediator.Send(new GetPostQueries() { Page = 1, Size = 1000 }).Result;
            return View("./ManagePost/PostDatatable", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    // Tag DataTable
    public async Task<IActionResult> TagDatatable()
    {
        try
        {
            var result = Mediator.Send(new GetAllTagQueries() { Page = 1, Size = 1000 }).Result;
            return View("./ManageTag/TagDatatable", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<IActionResult> CommentDatatable()
    {
        try
        {
            var result = Mediator.Send(new GetCommentRequest() { Page = 1, Size = 1000 }).Result;
            return View("./ManageComment/CommentDatatable", result);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<IActionResult> UpdateComment(Guid commentId)
    {
        try
        {
            
            //var isDeleted = Mediator.Send(new UpdateCommentCommands { Id = commentId }).Result;
            //return isDeleted ? Json("Deleted") : (IActionResult)Json("some thing went wrong ...");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return View();
    }
    public async Task<IActionResult> DeleteComment(Guid commentId)
    {
        try
        {
            var isDeleted = Mediator.Send(new DeleteCommentCommands { Id = commentId }).Result;
            return isDeleted ? Json("Deleted") : (IActionResult)Json("some thing went wrong ...");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
}
