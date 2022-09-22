using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class GetTaskListByDate
    {
        public string Date { get; set; }
        public int JobId { get; set; }
        public string NurseId { get; set; }
    }
}
