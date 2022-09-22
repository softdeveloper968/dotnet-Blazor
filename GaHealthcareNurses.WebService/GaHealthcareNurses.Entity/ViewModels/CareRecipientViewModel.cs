
namespace GaHealthcareNurses.Entity.ViewModels
{
  public class CareRecipientViewModel
    {
        public int CareRecipientId { get; set; }
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string ClientId { get; set; }
        public int? ServiceListId { get; set; }
        public int? CareRecipientLocationId { get; set; }
        public int? CareRecipientRelationshipId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    //    public string ZipCode { get; set; }
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
        public string MoreInformation { get; set; }
        public string ServiceTitle { get; set; }
        public string TotalHours { get; set; }
    }
}
