using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class Nurse
    {
        public Nurse()
        {
            Certifications = new HashSet<Certification>();
            Educations = new HashSet<Education>();
            References = new HashSet<Reference>();
            VisitNotes = new HashSet<VisitNote>();
            WorkExperiences = new HashSet<WorkExperience>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleInitial { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string ZipCode { get; set; }
        //public string CurrentLocation { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string SocialSecurityNo { get; set; }
        public bool Availability { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactAddress { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string AvailableHoursPerWeek { get; set; }
        public string PreferredHourlyRate { get; set; }
        public string PreferredHourlyRateUpto { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string ContactTime { get; set; }
        public Boolean? ContactPresentEmployer { get; set; }
        public Boolean? LawfullyBecomingEmployed { get; set; }
        public DateTime? DateAvailableToWork { get; set; }
        public int? HoursPerWeek { get; set; }
        public string AvailableToWork { get; set; }
        public Boolean? Trasnportation { get; set; }
        public Boolean? IneligibleForParticipation { get; set; }
        public  string ReasonForIneligible { get; set; }
        public Boolean? CriminalActivity { get; set; }
        public string ProfliePicture { get; set; }
        public string Resume { get; set; }
        public string ReasonForWork { get; set; }
        public string StepsInformation { get; set; }
        public string FirebaseToken { get; set; }
        public string DeviceType { get; set; }
        public bool IsUserAvailableForJob { get; set; }
        public bool? AgreeToApplicantStatement { get; set; }
        public bool? AgreeToNonDiscriminationDocument { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public int? ReferralCount { get; set; }
        public int? RegisteredCount { get; set; }
        public int? TotalRewards { get; set; }

        [Key]
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Reference> References { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }
        public virtual ICollection<WorkExperience> WorkExperiences { get; set; }

    }
}

