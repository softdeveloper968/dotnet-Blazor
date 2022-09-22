using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class HepatitisBSeriesInformation
    {
        public string Id { get; set; }
        public Boolean RefusedToTakeHepatitisBSeriesInPast { get; set; }
        public Boolean WantToHaveHepatitisBSeries { get; set; }
        public Boolean AlreadyHapititisBSeriesDone { get; set; }
    }
}
