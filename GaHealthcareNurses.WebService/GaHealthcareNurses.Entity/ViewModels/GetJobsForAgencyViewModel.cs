using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
   public class GetJobsForAgencyViewModel
    {
        public int JobId { get; set; }
        public string EmployerId { get; set; }

        public string ClientId { get; set; }
        public int CareRecipientId { get; set; }
        public int? JobTitleId { get; set; }
        //    public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public double HourlyRate { get; set; }
        public int? StatusId { get; set; }
        public virtual Status Status { get; set; }
        //   public int CityId { get; set; }
        public int? ResourceId { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual Client Client { get; set; }
        //    public virtual City City { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual CareRecipient CareRecipient { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public virtual ICollection<VisitNote> VisitNotes { get; set; }
    }
}
