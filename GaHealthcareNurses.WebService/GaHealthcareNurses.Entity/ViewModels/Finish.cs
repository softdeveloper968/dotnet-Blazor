using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class Finish
    {
        public virtual ICollection<ReferenceDto> ReferenceDto { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactAddress { get; set; }
        public string EmergencyContactPhone { get; set; }
        public string EmergencyContactRelationship { get; set; }
        public string ReasonForWork { get; set; }
        public string ProfliePicture { get; set; }
        public string Resume { get; set; }
        public bool IsUserAvailableForJob { get; set; }
        public bool? AgreeToApplicantStatement { get; set; }
        public bool? AgreeToNonDiscriminationDocument { get; set; }
        //[NotMapped]
        //  public IFormFile File { get; set; }
    }
}
