using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        public string CertificationType { get; set; }
        public string CertificationNumber { get; set; }
        public string CertificationState { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Type { get; set; }

        [ForeignKey("Nurse")]
        public string? NurseId { get; set; }
        public int? StateId { get; set; }
        public string Title { get; set; }
      
        public string AdditionInfo { get; set; }

        public virtual Nurse Nurse { get; set; }
        public virtual State State { get; set; }

    }
}

