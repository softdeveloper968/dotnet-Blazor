using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class PreferencesViewModel
    {
        public string UserId { get; set; }
        public string AvailableHoursPerWeek { get; set; }
        public string PreferredHourlyRate { get; set; }
        public string PreferredHourlyRateUpto { get; set; }
    }
}
