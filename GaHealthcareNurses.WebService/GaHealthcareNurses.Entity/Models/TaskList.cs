using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class TaskList
    {
        public int TaskListId { get; set; }
        public int? VisitNoteId { get; set; }
        public int JobId { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }
        [ForeignKey("Nurse")]
        public string NurseId { get; set; }
     //   public string Signature { get; set; }
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TotalTime { get; set; }
        public virtual VisitNote VisitNote { get; set; }
        public virtual Job Job { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Nurse Nurse { get; set; }

    }
}

