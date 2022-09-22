using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public class Client
    {
        public Client()
        {
            CareRecipients = new HashSet<CareRecipient>();
         //   RequiredServices = new HashSet<RequiredService>();

        }

        [Key]
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public int? CareRecipientRelationshipId { get; set; }

        //public int? RequiredServiceId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BestTimeToCal { get; set; }
        public string ReferralName { get; set; }
        public string HowYouHeardAboutUs { get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual CareRecipientRelationship CareRecipientRelationship { get; set; }
        //public virtual RequiredService RequiredService { get; set; }
       public virtual ICollection<CareRecipient> CareRecipients { get; set; }
      //  public virtual ICollection<RequiredService> RequiredServices { get; set; }

    }
}

