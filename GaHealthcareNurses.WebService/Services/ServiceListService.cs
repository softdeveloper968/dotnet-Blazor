using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Contracts.RepositoryContracts;

namespace Services
{
    public class ServiceListService : IServiceListService
    {
        private IServiceListRepository _serviceListRepository;

        #region Constructor for NurseService
        public ServiceListService(IServiceListRepository serviceListRepository)
        {
            _serviceListRepository = serviceListRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<ServiceList>> Get()
        {
            return await _serviceListRepository.Get();
        }

        public async Task<ServiceList> GetById(int id)
        {
            return await _serviceListRepository.GetById(id);
        }
        #endregion
    }
}
