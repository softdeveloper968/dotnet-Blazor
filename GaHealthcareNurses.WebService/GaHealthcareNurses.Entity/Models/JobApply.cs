using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
    public class JobApply
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        [ForeignKey("Nurse")]
        public string NurseId { get; set; }
        public virtual Nurse Nurse { get; set; }
        public string PrefferedRate { get; set; }
        public string PrefferedRateUpto { get; set; }
        public double RequiredHours { get; set; }
        public string OfferedRate { get; set; }
        public string ClientFeedback { get; set; }
        public string NurseFeedback { get; set; }
        public double? ClientRating { get; set; }
        public double? NurseRating { get; set; }
        public int? StatusId { get; set; }
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
        public virtual Status Status { get; set; }
    
    }
}
