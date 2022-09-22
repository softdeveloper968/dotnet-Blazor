using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class FeedbackViewModel
    {
        public int JobApplyId { get; set; }
        public string Feedback { get; set; }
        public double? Rating { get; set; }
    }
}
