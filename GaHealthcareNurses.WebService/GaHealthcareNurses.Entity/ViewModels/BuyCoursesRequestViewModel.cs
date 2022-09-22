using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class BuyCoursesRequestViewModel
    {
        public string intent { get; set; }
        public Payer payer { get; set; } 
        public List<TransactionViewModel> transactions { get; set; } 
        public RedirectUrls redirect_urls { get; set; }
        public string note_to_payer { get; set; }
    }
}
