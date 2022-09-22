using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class JobService : IJobService
    {
        private IJobRepository _jobRepository;
        private IStatusService _statusService;
        private IJobTitleService _jobTitleService;

        #region Constructor for JobService
        public JobService(IJobRepository jobRepository,IStatusService statusService, IJobTitleService jobTitleService)
        {
            _jobRepository = jobRepository;
            _statusService = statusService;
            _jobTitleService = jobTitleService;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Job>> Get(PaginationFilter paginationFilter)
        {
            return await _jobRepository.Get(paginationFilter);

        }

        public async Task<int> TotalCount(string filter)
        {
            return await _jobRepository.TotalCount(filter);
        }

        //public async Task<GetJobsForAgencyViewModel> GetJobsForAgency(PaginationFilter paginationFilter)
        //{
        //    return await _jobRepository.GetJobsForAgency(paginationFilter);
        //}

        public async Task<IEnumerable<Job>> GetJobsForAgency(int skip, int take,string filter)
        {
            return await _jobRepository.GetJobsForAgency(skip, take,filter);
        }

        public async Task<Job> GetById(int id)
        {
            return await _jobRepository.GetById(id);
        }

        public async Task<IEnumerable<Job>> GetByClientId(string id)
        {
            return await _jobRepository.GetByClientId(id);
        }

        public async Task<Job> Add(Job job)
        {
            job.StatusId = 5;
            var status = await _statusService.GetById((int)job.StatusId);
            job.Status = status;
            var jobTitle = await _jobTitleService.GetById((int)job.JobTitleId);
            job.JobTitle = jobTitle;
            return await _jobRepository.Add(job);
        }

        public async Task Delete(Job job)
        {
            await _jobRepository.Delete(job);
        }

        public async Task Update(Job job)
        {
            await _jobRepository.Update(job);
        }
        #endregion
    }
}
