using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class EducationService : IEducationService
    {
        private IEducationRepository _educationRepository;

        #region Constructor for EmployerService
        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Education>> Get()
        {
            return await _educationRepository.Get();
        }

        public async Task<Education> GetById(int id)
        {
            return await _educationRepository.GetById(id);
        }

        public async Task Add(Education education)
        {
            await _educationRepository.Add(education);
        }

        public async Task Delete(Education education)
        {
            await _educationRepository.Delete(education);
        }

        public async Task Update(Education education)
        {
            await _educationRepository.Update(education);
        }
        #endregion
    }
}
