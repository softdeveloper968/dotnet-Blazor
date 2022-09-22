using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class ExecutePaymentResponseViewModel
    {
        public string Id { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
        public DateTime Create_Time { get; set; }
        public DateTime Update_Time { get; set; } 
    }
}
