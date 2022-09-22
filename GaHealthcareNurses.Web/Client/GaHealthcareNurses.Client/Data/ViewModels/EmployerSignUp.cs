
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class EmployerSignUp
    {
        public string EmployerId { get; set; }

        //[RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Enter valid name")]
        [Required(ErrorMessage = "Agency name is required")]
        //[StringLength(32, ErrorMessage = "Agency name cannot be longer than 32 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address line 1 is required")]
        [StringLength(32, ErrorMessage = "Address line 1 cannot be longer than 32 characters.")]
        public string AddressLine1 { get; set; }

        //[Required(ErrorMessage = "Address line 2 is required")]
        [StringLength(32, ErrorMessage = "Address line 2 cannot be longer than 32 characters.")]
        public string AddressLine2 { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a city")]
        public int CityId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a state")]
        public int StateId { get; set; }

        public string ZipCode { get; set; }

        [RegularExpression(@"^[0-9]{3}[0-9]{3}[0-9]{4}$", ErrorMessage = "Enter valid phone number")]
        [Required(ErrorMessage = "Telephone number is required")]
        public string TelephoneNo { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter valid email")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage = "Password should contain minimum 6 characters,one special character,combination of uppercase and lowercase letters and a number")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and repeat password must match")]
        [Required(ErrorMessage = "Repeat password is required")]
        public string RepeatPassword { get; set; }
        public IFormFile Logo { get; set; }
        public byte[] LogoData { get; set; }
        public string FileName { get; set; }
    }
}
