using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class TransactionViewModel
    {
        public Amount amount { get; set; }
        public string description { get; set; }
        public string note_to_payee { get; set; }
    }
}
