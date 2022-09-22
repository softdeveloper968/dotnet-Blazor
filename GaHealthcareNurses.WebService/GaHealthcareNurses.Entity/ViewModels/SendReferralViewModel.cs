using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class SendReferralViewModel
    {
        public string NurseId { get; set; }
        public List<ReferralViewModel> Referrals { get; set; }
    }
}
