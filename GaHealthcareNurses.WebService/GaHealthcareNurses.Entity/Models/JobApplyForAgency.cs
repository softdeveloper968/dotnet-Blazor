using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
   public class JobApplyForAgency
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
        public string PrefferedRate { get; set; }
        public string PrefferedRateUpto { get; set; }
        public string OfferedRate { get; set; }
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
