using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
  public class Resource
    {
        public Resource()
        {
       //     Jobs = new HashSet<Job>();
        }
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
      //  public virtual ICollection<Job> Jobs { get; set; }

    }
}
