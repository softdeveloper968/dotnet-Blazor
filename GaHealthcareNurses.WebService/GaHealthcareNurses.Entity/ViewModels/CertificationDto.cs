using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class CertificationDto
    {
        //Step 4
        public int? CertificationId { get; set; }
        public string CertificationType { get; set; }
        public string CertificationNumber { get; set; }
        public string CertificationState { get; set; }
        public DateTime? DateOfExpiration { get; set; }
        public string Type { get; set; }

    }
}
