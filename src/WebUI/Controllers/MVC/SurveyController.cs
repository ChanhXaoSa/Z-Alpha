using MediatR;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ZAlpha.Application.AnswersForEntranceTest.Commands.CreateAnswersForEntranceTest;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.EntranceTest.Queries.GetAllEntranceTest;

namespace WebUI.Controllers.MVC;
public class SurveyController : ControllerBaseMVC
{
    private readonly IIdentityService _identityService;
    private readonly IToastNotification _notification;

    public SurveyController(IIdentityService identityService, IToastNotification notification)
    {
        _identityService = identityService;
        _notification = notification;
    }
    public async Task<IActionResult> Index()
    {
        try
        {
            var listquestion = await Mediator.Send(new GetEntranceTestRequest() { Page = 1, Size = 100 });
            ViewBag.listquestion = listquestion;
            return View();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);    
        }       
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnswer(
        string worrylevel, string problemDes, string recommendation, string activities,
        string Ques0, string Ques1, string Ques2, string Ques3)
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);

            if (worrylevel != null)
            {
                var answer0 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques0),
                    Answer = worrylevel,
                    IsCorrect = null,
                    CustomerAccountId = Guid.Parse(user.Id)
                }).Result;
            }
            if (problemDes != null)
            {
                var answer1 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques1),
                    Answer = problemDes,
                    IsCorrect = null,
                    CustomerAccountId = Guid.Parse(user.Id)
                }).Result;
            }
            if (recommendation != null)
            {
                var answer2 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques2),
                    Answer = recommendation,
                    IsCorrect = null,
                    CustomerAccountId = Guid.Parse(user.Id)
                }).Result;
            }
            if (activities != null)
            {
                var answer3 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques3),
                    Answer = activities,
                    IsCorrect = null,
                    CustomerAccountId = Guid.Parse(user.Id)
                }).Result;
            }
            return Redirect("~/Home");
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
