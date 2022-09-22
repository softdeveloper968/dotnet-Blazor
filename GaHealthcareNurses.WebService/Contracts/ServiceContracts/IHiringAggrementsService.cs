using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IHiringAggrementsService
    {
        Task<IEnumerable<HiringAgreements>> Get();
        Task<HiringAgreements> GetById(string id);
        Task AddHiringAggrement(HiringAgreements hiringAgreements);
      //  Task AddDeclinationOfInfluenzaVaccination(DeclinationOfInfluenzaVaccination declinationOfInfluenzaVaccination);
        Task UpdateHiringAggrement(HiringAgreements hiringAgreements);
    }
}
