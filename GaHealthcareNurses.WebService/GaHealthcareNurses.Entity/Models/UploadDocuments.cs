using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GaHealthcareNurses.Entity.Models
{
  public class UploadDocuments
    {
        [Key]
        [ForeignKey("Nurse")]
        public string Id { get; set; }
        public string CnaOrProfessionalLicense { get; set; }
        public string CprProvideNewLicense { get; set; }
        public string Ssn { get; set; }
        public string DrivingLicense { get; set; }
        public string TbTestResults { get; set; }
        public string StaffPortalInfo { get; set; }
        public string PcaTest { get; set; }
        public string HiringDisclosures { get; set; }
        public string HiringPreScreening { get; set; }
        public string OfficeWillPulled { get; set; }
        public string SexOffenderReportOfficeWillPulled { get; set; }
        public string EVerifyWillPulled { get; set; }
        public string BackgroundCheck { get; set; }
        public virtual Nurse Nurse { get; set; }

    }
    public class FileData
    {
        public byte[] Data { get; set; }
        public string FileType { get; set; }
        public long Size { get; set; }

    }
}
