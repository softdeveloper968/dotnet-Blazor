using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class JobTitleService : IJobTitleService
    {
        private IJobTitleRepository _jobTitleRepository;

        #region Constructor for JobTitleService
        public JobTitleService(IJobTitleRepository jobTitleRepository)
        {
            _jobTitleRepository = jobTitleRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<JobTitle>> Get()
        {
            return await _jobTitleRepository.Get();
        }

        public async Task<JobTitle> Add(JobTitle jobTitle)
        {
            return await _jobTitleRepository.Add(jobTitle);
        }

        public async Task<JobTitle> GetById(int id)
        {
            return await _jobTitleRepository.GetById(id);
        }
        #endregion
    }
}
