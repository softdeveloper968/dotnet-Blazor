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
    public class StateService : IStateService
    {
        private IStateRepository _stateRepository;

        #region Constructor for NurseService
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<State>> Get()
        {
            return await _stateRepository.Get();
        }
        public async Task<State> GetById(int id)
        {
            return await _stateRepository.GetById(id);
        }
        #endregion
    }
}
