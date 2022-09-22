using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class VisitNote
    {
        public VisitNote()
        {
            TaskLists = new HashSet<TaskList>();
        }
        [Key]
        public int VisitNoteId { get; set; }
        public int JobId { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }

        [ForeignKey("Nurse")]
        public string? NurseId { get; set; }
        public int? CareRecipientId { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string BillingCode { get; set; }
        public bool CheckTemperature { get; set; }
        public bool CheckBloodPressure { get; set; }
        public bool CheckPainRating { get; set; }
        public bool CheckWeight { get; set; }

        //  public virtual Job Job { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Nurse Nurse { get; set; }
        // public virtual CareRecipient CareRecipient { get; set; }
        public virtual ICollection<TaskList> TaskLists { get; set; }

    }
}

