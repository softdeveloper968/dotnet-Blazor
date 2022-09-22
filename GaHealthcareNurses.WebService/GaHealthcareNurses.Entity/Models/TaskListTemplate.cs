using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public class TaskListTemplate
    {
        public int TaskListTemplateId { get; set; }
        public string EmployerId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public int? TaskListCategoryId { get; set; }
        public virtual TaskListCategory TaskListCategory { get; set; }
    }
}

