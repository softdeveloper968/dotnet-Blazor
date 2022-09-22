using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class State
    {
        public State()
        {
            Clients = new HashSet<Client>();
         //   CareRecipients = new HashSet<CareRecipient>();
            Cities = new HashSet<City>();
        }

        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
      // public virtual ICollection<CareRecipient> CareRecipients { get; set; }
        public virtual ICollection<City> Cities { get; set; }

    }
}

