using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
  public class PermissionToShareDocumentsViewModel
    {
        public int JobApplyId { get; set; }
        public bool AcceptJobDescriptionAndPolicies { get; set; }
        public bool DocumentsCanBeShared { get; set; }
        public bool SSNCanBeShared { get; set; }
        public bool CNACanBeShared { get; set; }
        public bool CPRCanBeShared { get; set; }
        public bool DrivingLicenseCanBeShare { get; set; }
        public bool TBResultsCanBeShared { get; set; }
        public bool W4CanBeShared { get; set; }
        public bool HiringDisclosuresCanBeShared { get; set; }
        public bool HiringPreScreeningCanBeShared { get; set; }
        public bool G4CanBeShared { get; set; }
    }
}
