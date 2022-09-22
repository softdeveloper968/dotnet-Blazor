using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class ReferenceDto
    {
        public int? ReferenceId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Occupation { get; set; }
    }
}
