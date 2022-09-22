using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public class TaskListVerification
    {
        public int TaskListVerificationId { get; set; }
        public int JobId { get; set; }

        [ForeignKey("Nurse")]
        public string NurseId { get; set; }
        public string TaskDate { get; set; }
        public string Signature { get; set; }
        public DateTime? TaskVerifiedTime { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual Job Job { get; set; }
        public virtual Nurse Nurse { get; set; }
    }
}
