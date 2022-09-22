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
    public class EducationTypeService : IEducationTypeService
    {
        private IEducationTypeRepository _educationTypeRepository;

        #region Constructor for EmployerService
        public EducationTypeService(IEducationTypeRepository educationTypeRepository)
        {
            _educationTypeRepository = educationTypeRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<EducationType>> Get()
        {
            return await _educationTypeRepository.Get();
        }

        public async Task<EducationType> GetById(int id)
        {
            return await _educationTypeRepository.GetById(id);
        }

        public async Task Add(EducationType educationType)
        {
            await _educationTypeRepository.Add(educationType);
        }

        public async Task Delete(EducationType educationType)
        {
            await _educationTypeRepository.Delete(educationType);
        }

        public async Task Update(EducationType educationType)
        {
            await _educationTypeRepository.Update(educationType);
        }
        #endregion
    }
}
