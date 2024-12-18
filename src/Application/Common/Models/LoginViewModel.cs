﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZAlpha.Application.Common.Models;
public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
    // AuthenticationScheme is in Microsoft.AspNetCore.Authentication namespace
    public IList<AuthenticationSchemes>? ExternalLogins { get; set; }
}
