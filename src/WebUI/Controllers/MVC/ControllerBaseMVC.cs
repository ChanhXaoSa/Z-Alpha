using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;

[ApiExplorerSettings(IgnoreApi = true)]
public class ControllerBaseMVC : Controller
{
    private ISender _mediator = null!;

    protected ISender Mediator => _mediator ??=
        HttpContext.RequestServices.GetRequiredService<ISender>();
}
