using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class Employer
    {
        public Employer()
        {
          //  Jobs = new HashSet<Job>();
            VisitNotes = new HashSet<VisitNote>();
        }

        [Key]
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public string ZipCode { get; set; }
        public string TelephoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Logo { get; set; }
        public int? SubscriptionId { get; set; }
        public bool IsSubscriptionActive { get; set; }
        public bool IsSubscriptionRecurring { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual City City { get; set; }
        public virtual State State { get; set; }
     //   public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }

    }
}

