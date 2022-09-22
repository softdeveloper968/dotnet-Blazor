namespace GaHealthcareNurses.Entity.Models
{
    public class CareCoordinationNote
    {
        public int CareCoordinationNoteId { get; set; }
        public int? JobId { get; set; }
        public int? CareRecipientId { get; set; }
        public bool Physician { get; set; }
        public bool Don { get; set; }
        public bool RN_LPN_LVN { get; set; }
        public bool Aide { get; set; }
        public bool PT_PTA { get; set; }
        public bool OT_COTA { get; set; }
        public bool SLP { get; set; }
        public bool MSW { get; set; }
        public bool Pharmacist { get; set; }
        public bool TherapySupervisor { get; set; }
        public bool CaseManager { get; set; }
        public bool DmeVendor { get; set; }
        public bool CommunityResource { get; set; }
        public bool Other { get; set; }
        public string Discussion { get; set; }
        public string Resolution { get; set; }

       // public virtual CareRecipient CareRecipient { get; set; }

    }
}

