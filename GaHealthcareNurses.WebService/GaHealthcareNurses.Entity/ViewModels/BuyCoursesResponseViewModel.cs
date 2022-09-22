using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class BuyCoursesResponseViewModel
    {
        public string Id { get; set; }
        public string Intent { get; set; }
        public Payer Payer { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
        public List<Links> Links { get; set; }
    }
}
