using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class ResetPasswordModel
    {
      //  public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage = "Password should contain minimum 6 characters,one special character,combination of uppercase and lowercase letters and a number")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirm password must match")]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }

        public string Id { get; set; }
    }
}
