using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
   public class BuyCourses
    {
        public int Id { get; set; }

        public string PaymentId { get; set; }

        public string Description { get; set; }

        public DateTime? PurchasedDate { get; set; }

        [ForeignKey("Nurse")]
        public string NurseId { get; set; }

        public virtual Nurse Nurse { get; set; }
    }
}
