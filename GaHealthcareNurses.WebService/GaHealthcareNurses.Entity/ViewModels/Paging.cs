using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class Paging
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string? Filter { get; set; }
    }
}
