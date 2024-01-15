using ZAlpha.Application.Post.Queries.GetAllPost;
using ZAlpha.Application.Tag.Queries.GetTagById;
using ZAlpha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

public class HomeController : ControllerBaseMVC
{
    public IActionResult index() 
    {
        try
        {
            var result =  Mediator.Send(new GetPostQueries() { Page = 1, Size = 100 }).Result;
           /* List<Tag> tags = new List<Tag>();
            foreach(var item in result.Items)
            {
                if(item.PostTags != null)
                {
                    foreach(var postTag in item.PostTags){
                        var tag = Mediator.Send(new GetTagByIdQueries() { Id = postTag.TagId });
                        tags.Add(tag);
                    }
                }
            }*/
           




            return View(result);
            

            //return View();
        }
        catch (Exception ex)
        {
           throw new Exception(ex.Message);
        }

    }
}
