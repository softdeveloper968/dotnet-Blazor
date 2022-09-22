using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
    public class Referral
    {
        [Key]
        public int ReferralId { get; set; }
        [ForeignKey("Nurse")]
        public string NurseId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateReferred { get; set; }
        public DateTime? DateRegistered { get; set; }
        public bool EmailSent { get; set; }
        public string ReferralLink { get; set; }
        public virtual Nurse Nurse { get; set; }

    }
}
