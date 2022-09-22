using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class PaypalAccessTokenResponseModel
    {
        public string Scope { get; set; }
        public string Access_token { get; set; }
        public string Token_type { get; set; }
        public string App_id { get; set; }
        public double Expires_in { get; set; }
        public string Nonce { get; set; }
    }
}
