using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
   public class AgencyTaskList
    {
        public int Id { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }
        public int? TaskListTemplateId { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual TaskListTemplate TaskListTemplate { get; set; }
    }
}
