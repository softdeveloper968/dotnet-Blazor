using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class SubscriptionPostRequestViewModel
    {
        public string plan_id { get; set; }
        public string start_time { get; set; }
        public Subscriber subscriber { get; set; }
        public ApplicationContext application_context { get; set; }

    }
}
