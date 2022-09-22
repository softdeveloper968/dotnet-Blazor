using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class NurseWorkHistoryViewModel
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientMiddleInitial{get;set;}
        public string ClientFeedBack { get; set; }
        public double? ClientRating { get; set; }
        public string NurseFeedBack { get; set; }
        public double? NurseRating { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string Location { get; set; }
    }
}
