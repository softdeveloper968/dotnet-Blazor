using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.Models
{
    public class CareRecipientRelationship
    {
        public CareRecipientRelationship()
        {
            Clients = new HashSet<Client>();
            //CareRecipients = new HashSet<CareRecipient>();
        }

        public int CareRecipientRelationshipId { get; set; }
        public string Relationship { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
        //public virtual ICollection<CareRecipient> CareRecipients { get; set; }

    }
}

