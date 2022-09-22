using Contracts;
using Contracts.RepositoryContracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class HiringAggrementsService : IHiringAggrementsService
    {
        private IHiringAggrementsRepository _hiringAggrementsRepository;

        #region Constructor for HiringAggrementsService
        public HiringAggrementsService(IHiringAggrementsRepository hiringAggrementsRepository)
        {
            _hiringAggrementsRepository = hiringAggrementsRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task AddHiringAggrement(HiringAgreements hiringAgreements)
        {
            await _hiringAggrementsRepository.AddHiringAggrement(hiringAgreements);
        }

        //public async Task AddDeclinationOfInfluenzaVaccination(DeclinationOfInfluenzaVaccination declinationOfInfluenzaVaccination)
        //{
        //    var hiringAggrement = _hiringAggrementsRepository.GetById(declinationOfInfluenzaVaccination.Id);
        //    hiringAggrement.
        //}
        public async Task UpdateHiringAggrement(HiringAgreements hiringAgreements)
        {
            await _hiringAggrementsRepository.UpdateHiringAggrement(hiringAgreements);
        }
        public async Task<IEnumerable<HiringAgreements>> Get()
        {
            return await _hiringAggrementsRepository.Get();
        }

        public async Task<HiringAgreements> GetById(string id)
        {
            return await _hiringAggrementsRepository.GetById(id);
        }
        #endregion
    }
}
