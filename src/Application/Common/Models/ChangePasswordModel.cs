using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAlpha.Application.Common.Models;
public class ChangePasswordModel
{
    [Required]
    [Display(Name = "OldPassword")]
    public string OldPassword { get; set; }
    [Required]
    [Display(Name = "NewPassword")]
    public string NewPassword { get; set; }
    [Display(Name = "ConfirmPassword")]
    [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match")]
    public string ConfirmPassword { get; set; }
}
