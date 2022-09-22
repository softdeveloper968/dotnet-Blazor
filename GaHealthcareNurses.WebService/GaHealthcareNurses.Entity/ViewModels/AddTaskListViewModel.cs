using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class AddTaskListViewModel
    {
        public int JobId { get; set; }
        public string EmployerId { get; set; }
        public List<TaskListAddTemplateViewModel> TaskListAddTemplates { get; set; }
   
    }
}
