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
    public class JobApplyService : IJobApplyService
    {
        private IJobApplyRepository _jobApplyRepository;
        private IStatusService _statusService;
        private IJobService _jobService;

        #region Constructor for JobApplyService
        public JobApplyService(IJobApplyRepository jobApplyRepository, IStatusService statusService,IJobService jobService)
        {
            _jobApplyRepository = jobApplyRepository;
            _statusService = statusService;
            _jobService = jobService;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<JobApply>> Get()
        {
            return await _jobApplyRepository.Get();
        }

        public async Task<JobApply> GetById(int id)
        {
            return await _jobApplyRepository.GetById(id);
        }

        public async Task<IEnumerable<JobApply>> GetByJobId(int id)
        {
            return await _jobApplyRepository.GetByJobId(id);
        }

        public async Task<IEnumerable<JobApply>> GetByNurseId(string id)
        {
            return await _jobApplyRepository.GetByNurseId(id);
        }

        public async Task<IEnumerable<JobApply>> GetByStatusId(string nurseId,int statusId)
        {
            return await _jobApplyRepository.GetByStatusId(nurseId,statusId);
        }

        public async Task<IEnumerable<JobApply>> GetByJobIdAndStatusId(int jobId, int statusId)
        {
            return await _jobApplyRepository.GetByJobIdAndStatusId(jobId, statusId);
        }

        public async Task<JobApply> HireNurse(int id)
        {
            var job = await _jobApplyRepository.GetById(id);
            if (job != null)
            {
                job.StatusId = 2;
             return  await _jobApplyRepository.Update(job);
            }
            return job;
        }
        public async Task<JobApply> Add(JobApply job)
        {
            job.StatusId = 4;
            var status = await _statusService.GetById((int)job.StatusId);
            job.Status = status;
            job.AcceptJobDescriptionAndPolicies = true;
            return await _jobApplyRepository.Add(job);
        }

        public async Task Delete(JobApply job)
        {
            await _jobApplyRepository.Delete(job);
        }

        public async Task<JobApply> Update(JobApplyUpdateViewModel job)
        {
            var jobApplied = await _jobApplyRepository.GetById(job.Id);
            if (jobApplied != null)
            {
                jobApplied.JobId = job.JobId;
                jobApplied.NurseId = job.NurseId;
                jobApplied.OfferedRate = job.OfferedRate;
                jobApplied.PrefferedRate = job.PrefferedRate;
                jobApplied.RequiredHours = job.RequiredHours;
                jobApplied.StatusId = job.StatusId;
                jobApplied.Status = await _statusService.GetById((int)jobApplied.StatusId);
                var jobAppliedData= await _jobApplyRepository.Update(jobApplied);

                string templatePath = Environment.CurrentDirectory + @"\\EmailTemplates\JobOfferReplyTemplate.xml";
                var message = await this.SendEmailToUser(jobAppliedData, templatePath, EmailTemplateType.JobOffer.ToString());
                if (message == true)
                {
                    return jobAppliedData;
                }
            }
            return jobApplied;

        }

        public async Task<JobApply> NurseFeedback(FeedbackViewModel nurseFeedback)
        {
            var jobApply = await _jobApplyRepository.GetById(nurseFeedback.JobApplyId);
            if (jobApply != null)
            {
                jobApply.NurseFeedback = nurseFeedback.Feedback;
                jobApply.NurseRating = nurseFeedback.Rating;
                return await _jobApplyRepository.Update(jobApply);
            }
            return jobApply;
        }

        public async Task<JobApply> ClientFeedback(FeedbackViewModel clientFeedback)
        {
            var jobApply = await _jobApplyRepository.GetById(clientFeedback.JobApplyId);
            if (jobApply != null)
            {
                jobApply.ClientFeedback = clientFeedback.Feedback;
                jobApply.ClientRating = clientFeedback.Rating;
                return await _jobApplyRepository.Update(jobApply);
            }
            return jobApply;
        }

        public async Task<JobApply> PermissionForShareDocuments(PermissionToShareDocumentsViewModel permissionToShareDocuments)
        {
            var jobApply = await _jobApplyRepository.GetById(permissionToShareDocuments.JobApplyId);
            if (jobApply != null)
            {
                jobApply.AcceptJobDescriptionAndPolicies = permissionToShareDocuments.AcceptJobDescriptionAndPolicies;
                jobApply.DocumentsCanBeShared = permissionToShareDocuments.DocumentsCanBeShared;
                jobApply.SSNCanBeShared = permissionToShareDocuments.SSNCanBeShared;
                jobApply.CNACanBeShared = permissionToShareDocuments.CNACanBeShared;
                jobApply.CPRCanBeShared = permissionToShareDocuments.CPRCanBeShared;
                jobApply.DrivingLicenseCanBeShare = permissionToShareDocuments.DrivingLicenseCanBeShare;
                jobApply.TBResultsCanBeShared = permissionToShareDocuments.TBResultsCanBeShared;
                jobApply.W4CanBeShared = permissionToShareDocuments.W4CanBeShared;
                jobApply.HiringDisclosuresCanBeShared = permissionToShareDocuments.HiringDisclosuresCanBeShared;
                jobApply.HiringPreScreeningCanBeShared = permissionToShareDocuments.HiringPreScreeningCanBeShared;
                jobApply.G4CanBeShared = permissionToShareDocuments.G4CanBeShared;
                return await _jobApplyRepository.Update(jobApply);
            }
            return jobApply;
        }


        public async Task<bool> SendEmailToUser(JobApply job, string templatePath, string type)
        {
            try
            {
                string emailBody = string.Empty;
                emailBody = Utility.GetEmailTemplateValue(templatePath, "JobOfferReplyEmail/Body");
                emailBody = emailBody.Replace("@@@agencyName", job.Job.Employer.Name);
                emailBody = emailBody.Replace("@@@nurse", job.Nurse.FirstName + " " + job.Nurse.LastName);
                emailBody = emailBody.Replace("@@@reply", job.Status.Name);
                Utility.SendMailToUser(EnumHelper.GetDescription(EmailSubjectRole.JobOffer), job.Job.Employer.EmailAddress, emailBody);
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
