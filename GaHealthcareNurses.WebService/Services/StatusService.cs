using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GoogleMaps.LocationServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class StatusService : IStatusService
    {
        private IStatusRepository _statusRepository;

        #region Constructor for StatusService
        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<Status>> Get()
        {
            return await _statusRepository.Get();
        }

        public async Task<IEnumerable<Status>> GetByTypeId(int id)
        {
            return await _statusRepository.GetByTypeId(id);
        }

        public async Task<Status> GetById(int id)
        {
            return await _statusRepository.GetById(id);
        }

        public async Task<Status> Add(Status status)
        {
         return await _statusRepository.Add(status);
        }

        public async Task Delete(Status status)
        {
            await _statusRepository.Delete(status);
        }

        public async Task Update(Status job)
        {
            await _statusRepository.Update(job);
        }
        #endregion
    }
}
