using System.Collections.Generic;

namespace GaHealthcareNurses.Entity.Models
{
    public class EducationType
    {
        public EducationType()
        {
            Education = new HashSet<Education>();
        }

        public int EducationTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Education> Education { get; set; }
    }
}
