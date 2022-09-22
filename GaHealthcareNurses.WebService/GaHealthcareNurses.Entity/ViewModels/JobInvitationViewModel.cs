using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class JobInvitationViewModel
    {
       public List<SendJobViewModel> Jobs { get; set; }
        public List<SendEmployerViewModel> Employers { get; set; }
    }
}
