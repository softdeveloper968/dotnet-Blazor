namespace GaHealthcareNurses.Entity.ViewModels
{
    public class JobApplyForAgencyViewModel
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string EmployerId { get; set; }
        public string PrefferedRate { get; set; }
        public string OfferedRate { get; set; }
        public int? StatusId { get; set; }
    }
}
