using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class JobApplyUpdateViewModel
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string NurseId { get; set; }
        public string PrefferedRate { get; set; }
        public double RequiredHours { get; set; }
        public string OfferedRate { get; set; }
        public int? StatusId { get; set; }
    }
}
