using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Services
{
    public class RequiredServices : IRequiredService
    {
        private IRequiredServiceRepository _requiredServiceRepository;

        #region Constructor for RequiredService
        public RequiredServices(IRequiredServiceRepository requiredServiceRepository)
        {
            _requiredServiceRepository = requiredServiceRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<RequiredService>> Get()
        {
            return await _requiredServiceRepository.Get();
        }

        public async Task<RequiredService> GetById(int id)
        {
            return await _requiredServiceRepository.GetById(id);
        }

        public async Task Add(RequiredService requiredService)
        {
            await _requiredServiceRepository.Add(requiredService);
        }

        public async Task Delete(RequiredService requiredService)
        {
            await _requiredServiceRepository.Delete(requiredService);
        }

        public async Task Update(RequiredService requiredService)
        {
            await _requiredServiceRepository.Update(requiredService);
        }
        #endregion
    }
}
