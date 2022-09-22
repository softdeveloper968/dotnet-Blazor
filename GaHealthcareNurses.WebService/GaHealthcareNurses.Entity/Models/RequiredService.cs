using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class RequiredService
    {
 
        public RequiredService()
        {
            Jobs = new HashSet<Job>();
            CareRecipients = new HashSet<CareRecipient>();
        }
        [Key]
        public int RequiredServiceId { get; set; }

        [ForeignKey("Client")]
        public string? ClientId { get; set; }

        [ForeignKey("ServiceList")]
        public int? ServiceListId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ServiceList ServiceList { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<CareRecipient> CareRecipients { get; set; }

    }
}

