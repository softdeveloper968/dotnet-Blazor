using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{

    public partial class WorkExperience
    {
        [Key]
        public int WorkExperienceId { get; set; }

        [ForeignKey("Nurse")]
        public string NurseId { get; set; }
        public string Employer { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NameOfSupervisor { get; set; }
        public string YourDuties { get; set; }
        public double? HourlyRate { get; set; }
        public double? FinalHourlyRate { get; set; }
        public string ReasonForLeaving { get; set; }
        public bool IsContactAllowed { get; set; }
        public virtual Nurse Nurse { get; set; }

    }
}

