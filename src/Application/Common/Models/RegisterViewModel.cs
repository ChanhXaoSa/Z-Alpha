using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Models;
public class RegisterViewModel
{
    [Required]
    [Display(Name = "Username")]
    public string Username { get; set; }
    [Required]
    [Display(Name = "FirstName")]
    public string FirstName { get; set; }
    [Required]
    [Display(Name = "Lastname")]
    public string Lastname { get; set; }
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    [Required]
    [Display(Name = "Phone")]
    public string Phone { get; set; }

    [Required]
    [Display(Name = "Birthday")]
    public DateTime Birthday { get; set; }

    [Required]
    [Display(Name = "Address")]
    public string Address { get; set; }

    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }
    [Display(Name = "ConfirmPassword")]
    [Compare("Password", ErrorMessage = "Password and Confirmation Password do not match")]
    public string ConfirmPassword { get; set; }
}
