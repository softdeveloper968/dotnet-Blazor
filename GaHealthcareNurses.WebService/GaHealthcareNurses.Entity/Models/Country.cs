using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.Models
{
    public class Country
    {
        public Country()
        {
            States = new HashSet<State>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<State> States { get; set; }

    }
}

