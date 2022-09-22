using System;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class ClientViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }    
        public int? StateId { get; set; }
        public int? CityId { get; set; }
        public string Phone1 { get; set; }
        public string AddressLine1 { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime BestTimeToCal { get; set; }
        public string HowYouHeardAboutUs { get; set; }
    }
}
