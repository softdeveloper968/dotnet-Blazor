using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class OnApprovedData
    {
        public string orderID { get; set; }
        public string billingToken { get; set; }
        public string subscriptionID { get; set; }
        public string facilitatorAccessToken { get; set; }
    }

}
