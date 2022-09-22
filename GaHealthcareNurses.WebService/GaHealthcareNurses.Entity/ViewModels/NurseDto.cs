using System;
using System.ComponentModel.DataAnnotations;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class NurseDto
    {
        //Step 1
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string ZipCode { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string SocialSecurityNo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Step2
        public string ContactTime { get; set; }
        public Boolean ContactPresentEmployer { get; set; }
        public Boolean LawfullyBecomingEmployed { get; set; }
        public DateTime DateAvailableToWork { get; set; }
        public int HoursPerWeek { get; set; }
        public string AvailableToWork { get; set; }
        public Boolean Trasnportation { get; set; }
        public Boolean IneligibleForParticipation { get; set; }
        public string ReasonForIneligible { get; set; }
        public Boolean CriminalActivity { get; set; }
        
        //Step 5
        public string EmergencyContactName { get; set; }
        public string EmergencyContactAddress { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string ReasonForWork { get; set; }
        public string ProfliePicture { get; set; }
        public string Resume { get; set; }
    }

  public class NurseDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string StateName { get; set; }

    }
}
