using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class ReferralSignUp
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string SocialSecurityNo { get; set; }
        public string Password { get; set; }
        public string FirebaseToken { get; set; }
        public string DeviceType { get; set; }
       // public int? ReferralCount { get; set; }
        public int ReferralId { get; set; }
    }

    
}
