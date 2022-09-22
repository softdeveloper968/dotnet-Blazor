using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class JobViewModel
    {
        public int JobId { get; set; }
        public string EmployerId { get; set; }
        public string ClientId { get; set; }
        public int ServiceListId { get; set; }
        public int CareRecipientId { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public int? ResourceId { get; set; }
        public int? JobTitleId { get; set; }
    }
}
