﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers.MVC;
public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Info()
    {
        return View();
    }
}
