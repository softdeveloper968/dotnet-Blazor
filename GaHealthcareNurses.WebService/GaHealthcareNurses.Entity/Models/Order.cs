using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
  public class Order
    {
        public string OrderId { get; set; }
        public string Status { get; set; }
        [ForeignKey("Employer")]
        public string EmployerId { get; set; }
        public virtual Employer Employer { get; set; }
    }
}
