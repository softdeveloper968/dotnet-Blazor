using GaHealthcareNurses.Entity.Models;
using System;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class EducationDto
    {
        public int? EducationId { get; set; }
        public int? EducationTypeId { get; set; }
        public string CompleteAddress { get; set; }
        public DateTime? AttendedFrom { get; set; }
        public DateTime? AttendedTo { get; set; }
        public string Major { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string SpecializedTraining { get; set; }
        public string OtherQualification { get; set; }

    }
}
