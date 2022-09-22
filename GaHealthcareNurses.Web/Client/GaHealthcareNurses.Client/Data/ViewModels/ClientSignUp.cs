using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class ClientSignUp
    {
        public string Id { get; set; }

        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Enter valid first name")]
        [StringLength(32, ErrorMessage = "First name cannot be longer than 32 characters.")]
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Enter valid middle name")]
        [StringLength(32, ErrorMessage = "Middle initial cannot be longer than 32 characters.")]
        public string MiddleInitial { get; set; }

        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Enter valid last name")]
        [StringLength(32, ErrorMessage = "Last name cannot be longer than 32 characters.")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a  State")]
        public int StateId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Select a  City")]
        public int CityId { get; set; }

       // [RegularExpression(@"^[0-9]{3}[0-9]{3}[0-9]{4}$", ErrorMessage = "Enter valid phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        public string Phone1 { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string AddressLine1 { get; set; }

        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Enter valid email")]
        [Required(ErrorMessage = "Email is required")]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{6,}$", ErrorMessage = "Password should contain minimum 6 characters,one special character,combination of uppercase and lowercase letters and a number")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and repeat password must match")]
        [Required(ErrorMessage = "Repeat password is required")]
        public string RepeatPassword { get; set; }

        //[Required]
        //public string BestTimeToCal { get; set; }

        public string HowYouHeardAboutUs { get; set; }
    }
}
