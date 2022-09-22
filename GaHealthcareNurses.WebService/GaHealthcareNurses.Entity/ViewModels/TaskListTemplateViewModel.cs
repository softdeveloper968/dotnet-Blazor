using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class TaskListTemplateViewModel
    {
        public int TaskListTemplateId { get; set; }
        public string EmployerId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int? TaskListCategoryId { get; set; }
    }
}
