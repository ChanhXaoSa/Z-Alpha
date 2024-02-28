using MediatR;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using ZAlpha.Application.AnswersForEntranceTest.Commands.CreateAnswersForEntranceTest;
using ZAlpha.Application.AnswersForEntranceTest.Queries.GetAnswersForEntranceTest;
using ZAlpha.Application.Common.Interfaces;
using ZAlpha.Application.CustomerAccount.Queries.GetCustomerAccountById;
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
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);

            var checkrole = await _identityService.IsInRoleAsync(user.Id, "Customer");
            // Nếu không phải là Customer thì không được phép truy cập
            if (checkrole == false)
            {
                return Redirect("~/Home");
            }
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;
            var listquestion = await Mediator.Send(new GetEntranceTestRequest() { Page = 1, Size = 100 });
            
            var listanswer = Mediator.Send(new GetAnswersForEntranceTestRequest() { Page = 1, Size = 100 }).Result;
            foreach (var item in listanswer.Items)
            {
                if (item.CustomerAccountId == result.Id && item.Created.Date == DateTime.Now.Date)
                {
                    return Redirect("~/Home");
                }
            }

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
        string worrylevel, string problemDes, string recommendation, 
        string sleep, string MusicMovie, string Coffe, string Social, string Overthinking,
        string Ques0, string Ques1, string Ques2, string Ques3)
    {
        try
        {
            var user = await _identityService.GetUserByNameAsync(User.Identity.Name);
            var result = Mediator.Send(new GetCustomerAccountByUserIdQueries() { UserAccountId = user.Id }).Result;

            if (worrylevel != null)
            {
                var answer0 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques0),
                    Answer = worrylevel,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (problemDes != null)
            {
                var answer1 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques1),
                    Answer = problemDes,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (recommendation != null)
            {
                var answer2 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques2),
                    Answer = recommendation,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (sleep != null)
            {
                var answer3 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques3),
                    Answer = sleep,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (MusicMovie != null)
            {
                var answer4 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques3),
                    Answer = MusicMovie,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (Coffe != null)
            {
                var answer5 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques3),
                    Answer = Coffe,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (Social != null)
            {
                var answer6 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques3),
                    Answer = Social,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }
            if (Overthinking != null)
            {
                var answer7 = Mediator.Send(new CreateAnswersForEntranceTestCommands()
                {
                    EntranceTestId = Guid.Parse(Ques3),
                    Answer = Overthinking,
                    IsCorrect = null,
                    CustomerAccountId = result.Id
                }).Result;
            }

            return Redirect("~/Home");
        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
