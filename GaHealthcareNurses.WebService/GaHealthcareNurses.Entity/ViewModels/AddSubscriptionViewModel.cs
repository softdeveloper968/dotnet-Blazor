using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class AddSubscriptionViewModel
    {
        public string SubscriptionId { get; set; }
        public string EmployerId { get; set; }
        public string Status { get; set; }
        public int PlanId { get; set; }
    }
}
