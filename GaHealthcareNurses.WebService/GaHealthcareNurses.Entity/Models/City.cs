using System;
using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.Models
{

    public class City
    {
        public City()
        {
            Clients = new HashSet<Client>();
         //   CareRecipients = new HashSet<CareRecipient>();
          //  Jobs = new HashSet<Job>();
        }

        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public string NameAndZipcode
        {
            get { return String.Format("{0}({1})", Name, ZipCode); }
            // public virtual ICollection<CareRecipient> CareRecipients { get; set; }
            //  public virtual ICollection<Job> Jobs { get; set; }
        }
        }
}

