using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Common;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Services
{
   public class JobInvitationService : IJobInvitationService
    {
        private readonly IJobApplyForAgencyService _jobApplyForAgencyService;
        private readonly IEmployerService _employerService;

        #region Constructor for JobInvitationService
        public JobInvitationService(IJobApplyForAgencyService jobApplyForAgencyService, IEmployerService employerService)
        {
            _jobApplyForAgencyService = jobApplyForAgencyService;
            _employerService = employerService;
        }
        #endregion
        public async Task<int> SendJobInvitation(List<SendJobViewModel> jobs , List<SendEmployerViewModel> employers)
        {
            int emailCount = 0;
            foreach (var job in jobs)
            {
                foreach (var employer in employers)
                {
                    var employerData = await _employerService.GetById(employer.EmployerId);
                    string templatePath = Environment.CurrentDirectory + @"\\EmailTemplates\JobInvitationTemplate.xml";
                    var message = await this.SendEmailToUser(employerData, job, templatePath, EmailTemplateType.JobInvitation.ToString());
                    if (message == true)
                    {
                        emailCount += 1;

                        JobApplyForAgency jobApply = new JobApplyForAgency
                        {
                            JobId = job.JobId,
                            EmployerId = employer.EmployerId,
                            StatusId = 11
                        };
                        await _jobApplyForAgencyService.Add(jobApply);
                    }
                }
            }
                
            return emailCount;
        }


       public async Task<bool> SendEmailToUser(Employer employer,SendJobViewModel job, string templatePath, string type)
        {
            try
            {
                string emailBody = string.Empty;
                emailBody = Utility.GetEmailTemplateValue(templatePath, "JobInvitationEmail/Body");
                emailBody = emailBody.Replace("@@@username", employer.Name);
                emailBody = emailBody.Replace("@@@job", job.JobTitle);
                emailBody = emailBody.Replace("@@@id", employer.Id);

                Utility.SendMailToUser(EnumHelper.GetDescription(EmailSubjectRole.Invitation), employer.EmailAddress, emailBody);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
