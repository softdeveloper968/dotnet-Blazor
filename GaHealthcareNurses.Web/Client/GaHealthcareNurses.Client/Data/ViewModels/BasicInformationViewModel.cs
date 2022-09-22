using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class BasicInformationViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Select a  Service")]
        public int ServiceListId { get; set; }

        [Required(ErrorMessage ="Start date is required")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage ="Time is required")]
        public DateTime? Time { get; set; }
        public string WhenToStart { get; set; }

        [Required(ErrorMessage ="End date is required")]
     //   [Range(typeof(DateTime), "03/04/2021", "12/12/9999", ErrorMessage = "Enter valid date")]
        public DateTime? EndDate { get; set; }
        public WeekDays Days { get; set; }
        public string Frequency { get; set; }
        public int TotalHours { get; set; }

    }
}
