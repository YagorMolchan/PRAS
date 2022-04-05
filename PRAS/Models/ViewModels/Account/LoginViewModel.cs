using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Models.ViewModels.Account
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "EmailRequired")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }

        //[Display(Name = "Запомнить меня")]
        //public bool RememberMe { get; set; }
    }
}
