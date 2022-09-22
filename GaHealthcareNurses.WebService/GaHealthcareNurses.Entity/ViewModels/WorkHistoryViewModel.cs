using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class WorkHistoryViewModel
    {
        public string StartingDate { get; set; }
        public string EndingDate { get; set; }
        public string NurseId { get; set; }
        public int JobId { get; set; }

    }
}
