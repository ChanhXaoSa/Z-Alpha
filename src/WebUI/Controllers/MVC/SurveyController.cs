using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZAlpha.Application.EntranceTest.Queries.GetAllEntranceTest;

namespace WebUI.Controllers.MVC;
public class SurveyController : ControllerBaseMVC
{
    public async Task<IActionResult> Index()
    {
        var listquestion = await Mediator.Send(new GetEntranceTestRequest() { Page = 1, Size = 100 });
        ViewBag.listquestion = listquestion;
        return View();
    }
}
