using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
  public interface IHiringAggrementsRepository
    {
        Task<IEnumerable<HiringAgreements>> Get();
        Task<HiringAgreements> GetById(string id);
        Task AddHiringAggrement(HiringAgreements hiringAgreements);
        Task UpdateHiringAggrement(HiringAgreements hiringAgreements);
    }
}
