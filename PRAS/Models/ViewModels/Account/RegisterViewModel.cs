using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Models.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Display(Name = "Email")]        
        [EmailAddress(ErrorMessage ="EmailFormat")]
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "PasswordsDontMatch")]
        [Required(ErrorMessage = "ConfirmPasswordRequired")]
        public string ConfirmPassword { get; set; }
    }
}
