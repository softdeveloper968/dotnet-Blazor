using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{

    public class CareRecipient
    {
        public CareRecipient()
        {
            CareCoordinationNotes = new HashSet<CareCoordinationNote>();
            VisitNotes = new HashSet<VisitNote>();
        }
        [Key]
        public int CareRecipientId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public int ServiceListId { get; set; }
        public int? CareRecipientLocationId { get; set; }
        public int? CareRecipientRelationshipId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
      //  public string ZipCode { get; set; }
        public string CodeStatus { get; set; }
        public string Allergies { get; set; }
        public string Diagnosis { get; set; }
        public bool Alert { get; set; }
        public bool Forgetful { get; set; }
        public string PhoneNo { get; set; }
        public string PostalCode { get; set; }
        public string FunctionalLimitation { get; set; }
        public string Frequency { get; set; }
        public string GenderPreference { get; set; }
        public string NoteToCaregiver { get; set; }
        public string Receptiveness { get; set; }
        public string WhenToStart { get; set; }
        public string EndDate { get; set; }
        public string ServiceTitle { get; set; }
        public string MoreInformation { get; set; }
        public string TotalHours { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual Client Client { get; set; }
        public virtual CareRecipientLocation CareRecipientLocation { get; set; }
        public virtual CareRecipientRelationship CareRecipientRelationship { get; set; }
        public virtual ServiceList ServiceList { get; set; }
        public virtual ICollection<CareCoordinationNote> CareCoordinationNotes { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }

    }
}

