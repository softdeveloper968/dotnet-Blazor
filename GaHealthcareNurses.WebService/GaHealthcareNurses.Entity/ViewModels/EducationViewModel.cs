using System;
using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class EducationViewModel
    {
        public virtual ICollection<EducationDto> EducationDto { get; set; }
        public virtual ICollection<CertificationDto> CertificationDto { get; set; }

    }
}
