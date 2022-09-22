using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class Reference
    {
        [Key]
        public int ReferenceId { get; set; }

        [ForeignKey("Nurse")]
        public string? NurseId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Occupation { get; set; }
        public string EmailAddress { get; set; }
        public virtual Nurse Nurse { get; set; }

    }
}

