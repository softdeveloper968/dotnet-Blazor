using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class CareRecipientInformationModel
    {
        public int CareRecipientId { get; set; }
        public int ServiceListId { get; set; }
        public string ClientId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string WhenToStart { get; set; }
        public string EndDate { get; set; }
        public WeekDays Days { get; set; }
        public string Frequency { get; set; }

        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Enter valid first name")]
        [StringLength(32, ErrorMessage = "First name cannot be longer than 32 characters.")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }

        [RegularExpression(@"^(?<firstchar>(?=[A-Za-z]))((?<alphachars>[A-Za-z])|(?<specialchars>[A-Za-z]['-](?=[A-Za-z]))|(?<spaces> (?=[A-Za-z])))*$", ErrorMessage = "Enter valid last name")]
        [StringLength(32, ErrorMessage = "Last name cannot be longer than 32 characters.")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Enter valid age")]
        [Required(ErrorMessage = "Enter age")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(32, ErrorMessage = "Address cannot be longer than 32 characters.")]
        public string AddressLine1 { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a  State")]
        public int StateId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Select a  City")]
        public int CityId { get; set; }
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Select a gender")]
        public string GenderPreference { get; set; }

        //[Required(ErrorMessage = "Job title is required")]
        //public string ServiceTitle { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Select a  job title")]
        public int JobTitleId { get; set; }

        [Required(ErrorMessage = "Job description is required")]
        public string MoreInformation { get; set; }
        public ServiceList ServiceList { get; set; }
        public City City { get; set; }
        public State State { get; set; }
        public JobTitle JobTitle { get; set; }
        public string TotalHours { get; set; }
    }
}
