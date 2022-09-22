using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class SubscriptionResponseViewModel
    {
        public string Status { get; set; }
        public string Id { get; set; }
        public string Create_time { get; set; }
        public ICollection<Links> Links { get; set; }
    }
}
