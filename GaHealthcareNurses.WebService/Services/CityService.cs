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
    public class CityService : ICityService
    {
        private ICityRepository _cityRepository;

        #region Constructor for NurseService
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> Get()
        {
            return await _cityRepository.Get();
        }

        public async Task<City> GetById(int id)
        {
            return await _cityRepository.GetById(id);
        }

        public async Task<IEnumerable<City>> GetByStateId(int stateId)
        {
            return await _cityRepository.GetByStateId(stateId);
        }
        #endregion

        #region Implementing Interface

        #endregion
    }
}
