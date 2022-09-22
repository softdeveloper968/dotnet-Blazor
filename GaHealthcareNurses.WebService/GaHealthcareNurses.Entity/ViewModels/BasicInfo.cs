using System;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class BasicInfo
    {
        public string ContactTime { get; set; }
        public Boolean? ContactPresentEmployer { get; set; }
        public Boolean? LawfullyBecomingEmployed { get; set; }
        public DateTime? DateAvailableToWork { get; set; }
        public int? HoursPerWeek { get; set; }
        public string AvailableToWork { get; set; }
        public Boolean? Trasnportation { get; set; }
        public Boolean? IneligibleForParticipation { get; set; }
        public string ReasonForIneligible { get; set; }
        public Boolean? CriminalActivity { get; set; }
    }
}
