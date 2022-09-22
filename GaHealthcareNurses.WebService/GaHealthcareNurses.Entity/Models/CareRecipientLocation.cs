using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.Models
{

    public class CareRecipientLocation
    {
        public CareRecipientLocation()
        {
     //       CareRecipients = new HashSet<CareRecipient>();
        }

        public int CareRecipientLocationId { get; set; }
        public string CurrentLocation { get; set; }

     //   public virtual ICollection<CareRecipient> CareRecipients { get; set; }

    }
}

