using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        [ForeignKey("Nurse")]
        public string? NurseId { get; set; }
        public int? EducationTypeId { get; set; }
        public string CompleteAddress { get; set; }
        public DateTime? AttendedFrom { get; set; }
        public DateTime? AttendedTo { get; set; }
        public string Institution { get; set; }
        public string Major { get; set; }
        public string SpecializedTraining { get; set; }
        public string Type { get; set; }
        public string OtherQualification { get; set; }
        public virtual Nurse Nurse { get; set; }
        public virtual EducationType EducationType { get; set; }
        //public virtual ICollection<EducationType> EducationTypes { get; set; }

    }
}

