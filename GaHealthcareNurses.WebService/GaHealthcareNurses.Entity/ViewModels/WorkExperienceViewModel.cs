using System;
using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class WorkExperienceViewModel
    {
        public virtual ICollection<WorkExperienceDto> WorkExperienceDto { get; set; }
    }
}
