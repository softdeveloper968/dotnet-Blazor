using Microsoft.AspNetCore.Http;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class UploadDocumentsViewModel
    {
        public string Id { get; set; }
        public IFormFile CnaOrProfessionalLicense { get; set; }
        public IFormFile CprProvideNewLicense { get; set; }
        public IFormFile Ssn { get; set; }
        public IFormFile DrivingLicense { get; set; }
        public IFormFile TbTestResults { get; set; }
        public IFormFile StaffPortalInfo { get; set; }
        public IFormFile PcaTest { get; set; }
        public IFormFile HiringDisclosures { get; set; }
        public IFormFile HiringPreScreening { get; set; }
        public IFormFile OfficeWillPulled { get; set; }
        public IFormFile SexOffenderReportOfficeWillPulled { get; set; }
        public IFormFile EVerifyWillPulled { get; set; }
        public IFormFile BackgroundCheck { get; set; }
    }
}
