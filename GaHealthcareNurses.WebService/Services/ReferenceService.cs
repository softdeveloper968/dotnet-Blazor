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
    public class ReferenceService : IReferenceService
    {
        private IReferenceRepository _referenceRepository;

        #region Constructor for EmployerService
        public ReferenceService(IReferenceRepository referenceRepository)
        {
            _referenceRepository = referenceRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Reference>> Get()
        {
            return await _referenceRepository.Get();
        }

        public async Task<Reference> GetById(int id)
        {
            return await _referenceRepository.GetById(id);
        }

        public async Task Add(Reference reference)
        {
            await _referenceRepository.Add(reference);
        }

        public async Task Delete(Reference reference)
        {
            await _referenceRepository.Delete(reference);
        }

        public async Task Update(Reference reference)
        {
            await _referenceRepository.Update(reference);
        }
        #endregion
    }
}
