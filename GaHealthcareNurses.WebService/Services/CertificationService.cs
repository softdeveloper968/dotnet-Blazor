using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CertificationService : ICertificationService
    {
        private ICertificationRepository _certificationRepository;

        #region Constructor for EmployerService
        public CertificationService(ICertificationRepository certificationRepository)
        {
            _certificationRepository = certificationRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Certification>> Get()
        {
            return await _certificationRepository.Get();
        }

        public async Task<Certification> GetById(int id)
        {
            return await _certificationRepository.GetById(id);
        }

        public async Task Add(Certification certification)
        {
            await _certificationRepository.Add(certification);
        }

        public async Task Delete(Certification certification)
        {
            await _certificationRepository.Delete(certification);
        }

        public async Task Update(Certification certification)
        {
            await _certificationRepository.Update(certification);
        }
        #endregion
    }
}
