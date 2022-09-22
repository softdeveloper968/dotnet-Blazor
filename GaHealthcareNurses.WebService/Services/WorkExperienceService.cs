using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private IWorkExperienceRepository _workExperienceRepository;

        #region Constructor for EmployerService
        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository)
        {
            _workExperienceRepository = workExperienceRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<WorkExperience>> Get()
        {
            return await _workExperienceRepository.Get();
        }

        public async Task<WorkExperience> GetById(int id)
        {
            return await _workExperienceRepository.GetById(id);
        }

        public async Task Add(WorkExperience workExperience)
        {
            await _workExperienceRepository.Add(workExperience);
        }

        public async Task Delete(WorkExperience workExperience)
        {
            await _workExperienceRepository.Delete(workExperience);
        }

        public async Task Update(WorkExperience workExperience)
        {
            await _workExperienceRepository.Update(workExperience);
        }
        #endregion
    }
}
