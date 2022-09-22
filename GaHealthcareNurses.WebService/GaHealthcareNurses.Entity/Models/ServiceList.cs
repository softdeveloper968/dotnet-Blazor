using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
 public class ServiceList
    {
        public ServiceList()
        {
            // RequiredServices = new HashSet<RequiredService>();
            CareRecipients = new HashSet<CareRecipient>();
        }

        public int ServiceListId { get; set; }
       public string Name { get; set; }
        public virtual ICollection<CareRecipient> CareRecipients { get; set; }

       // public virtual ICollection<RequiredService> RequiredServices { get; set; }
    }
}
