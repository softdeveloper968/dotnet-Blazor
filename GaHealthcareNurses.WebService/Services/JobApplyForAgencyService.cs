using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Common;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class JobApplyForAgencyService : IJobApplyForAgencyService
    {
        private IJobApplyForAgencyRepository _jobApplyForAgencyRepository;
        private IStatusService _statusService;
        private IJobService _jobService;

        #region Constructor for JobApplyForAgencyService
        public JobApplyForAgencyService(IJobApplyForAgencyRepository jobApplyForAgencyRepository, IStatusService statusService, IJobService jobService)
        {
            _jobApplyForAgencyRepository = jobApplyForAgencyRepository;
            _statusService = statusService;
            _jobService = jobService;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<JobApplyForAgency>> Get()
        {
            return await _jobApplyForAgencyRepository.Get();
        }

        public async Task<JobApplyForAgency> GetById(int id)
        {
            return await _jobApplyForAgencyRepository.GetById(id);
        }

        public async Task<IEnumerable<JobApplyForAgency>> GetByJobId(int id)
        {
            return await _jobApplyForAgencyRepository.GetByJobId(id);
        }

        public async Task<IEnumerable<JobApplyForAgency>> GetByEmployerId(string id)
        {
            return await _jobApplyForAgencyRepository.GetByEmployerId(id);
        }

        public async Task<IEnumerable<JobApplyForAgency>> GetByStatusId(string employerId, int statusId)
        {
            return await _jobApplyForAgencyRepository.GetByStatusId(employerId, statusId);
        }

        public async Task<JobApplyForAgency> Add(JobApplyForAgency job)
        {
            return await _jobApplyForAgencyRepository.Add(job);
        }

        public async Task Delete(JobApplyForAgency job)
        {
            await _jobApplyForAgencyRepository.Delete(job);
        }

        public async Task<JobApplyForAgency> Update(JobApplyForAgency job)
        {
            return await _jobApplyForAgencyRepository.Update(job);
        }

        public async Task<JobApplyForAgency> ApplyJob(int jobApplyId, string prefferedRate)
        {
            var jobApplied = await _jobApplyForAgencyRepository.GetById(jobApplyId);
            if (jobApplied != null)
            {
                string templatePath = Environment.CurrentDirectory + @"\\EmailTemplates\JobAppliedTemplate.xml";
                var message = await this.SendEmailToUser(jobApplied, prefferedRate, templatePath, EmailTemplateType.JobApplied.ToString());
                if (message == true)
                {
                    jobApplied.PrefferedRate = prefferedRate;
                   
                    jobApplied.StatusId = 12;
                    return await _jobApplyForAgencyRepository.Update(jobApplied);
                }
                return null;
            }
            return jobApplied;
        }


        public async Task<bool> SendEmailToUser(JobApplyForAgency job, string prefferedRate, string templatePath, string type)
        {
            try
            {
                string emailBody = string.Empty;
                emailBody = Utility.GetEmailTemplateValue(templatePath, "JobInvitationEmail/Body");
                emailBody = emailBody.Replace("@@@client", job.Job.Client.FirstName);
                emailBody = emailBody.Replace("@@@prefferedRate", prefferedRate);
                emailBody = emailBody.Replace("@@@agency", job.Employer.Name);
                emailBody = emailBody.Replace("@@@job", job.Job.JobTitle.Title);
                emailBody = emailBody.Replace("@@@applyId", job.Id.ToString());


                Utility.SendMailToUser(EnumHelper.GetDescription(EmailSubjectRole.InvitationAccept), job.Job.Client.EmailAddress, emailBody);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<JobApplyForAgency> HireAgency(int jobApplyId)
        {
            var jobApply = await _jobApplyForAgencyRepository.GetById(jobApplyId);
            if (jobApply != null)
            {
                string templatePath = Environment.CurrentDirectory + @"\\EmailTemplates\JobOfferTemplate.xml";
                var message = await this.SendEmailToAgency(jobApply, templatePath, EmailTemplateType.JobOffer.ToString());
                if (message == true)
                {
                    jobApply.StatusId = 13;
                    jobApply.Job.SentToNurse = true;
                    jobApply.Job.EmployerId = jobApply.EmployerId;
                    return await _jobApplyForAgencyRepository.Update(jobApply);
                }
            }
            return jobApply;
        }


        public async Task<bool> SendEmailToAgency(JobApplyForAgency job,string templatePath,string type)
        {
            try
            {
                string emailBody = string.Empty;
                emailBody = Utility.GetEmailTemplateValue(templatePath, "JobOfferEmail/Body");
                emailBody = emailBody.Replace("@@@name", job.Employer.Name);
                emailBody = emailBody.Replace("@@@client", job.Job.Client.FirstName + " " + job.Job.Client.LastName);

                Utility.SendMailToUser(EnumHelper.GetDescription(EmailSubjectRole.JobOffer), job.Employer.EmailAddress, emailBody);

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
