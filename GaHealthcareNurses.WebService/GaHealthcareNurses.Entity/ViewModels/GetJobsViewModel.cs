using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class GetJobsViewModel
    {
        public int JobId { get; set; }
        public int? JobApplyId { get; set; }
        public string EmployerId { get; set; }
        public string ClientId { get; set; }
        public int CareRecipientId { get; set; }
        public JobTitle JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public int HourlyRate { get; set; }
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        //   public int CityId { get; set; }
        public int? ResourceId { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Client Client { get; set; }
        //    public virtual City City { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual CareRecipient CareRecipient { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }
        public virtual ICollection<JobApply> JobApplies { get; set; }
        public string AppliedRate { get; set; }
        public string OfferedRate { get; set; }
        public bool AcceptJobDescriptionAndPolicies { get; set; }
        public bool DocumentsCanBeShared { get; set; }
        public bool SSNCanBeShared { get; set; }
        public bool CNACanBeShared { get; set; }
        public bool CPRCanBeShared { get; set; }
        public bool DrivingLicenseCanBeShare { get; set; }
        public bool TBResultsCanBeShared { get; set; }
        public bool W4CanBeShared { get; set; }
        public bool HiringDisclosuresCanBeShared { get; set; }
        public bool HiringPreScreeningCanBeShared { get; set; }
        public bool G4CanBeShared { get; set; }
        //public string ClientFeedback { get; set; }
        //public string NurseFeedback { get; set; }
        //public double? ClientRating { get; set; }
        //public double? NurseRating { get; set; }
    }
}
