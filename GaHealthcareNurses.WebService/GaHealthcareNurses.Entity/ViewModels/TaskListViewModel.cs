using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class TaskListViewModel
    {
        public int TaskListId { get; set; }
        public int? VisitNoteId { get; set; }
        public int JobId { get; set; }
        public string EmployerId { get; set; }
        public string NurseId { get; set; }
     //   public string Verified { get; set; }
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
      //  public string TotalTime { get; set; }
    }
}
