namespace GaHealthcareNurses.Entity.ViewModels
{
    public class JobApplyViewModel
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string NurseId { get; set; }
        public string PrefferedRate { get; set; }
        public string PrefferedRateUpto { get; set; }
        public double RequiredHours { get; set; }
        public string OfferedRate { get; set; }
        public int? StatusId { get; set; }
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
       // public virtual Status Status { get; set; }
    }
}
