using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
   public interface ICityService
    {
        Task<IEnumerable<City>> Get();
        Task<City> GetById(int id);
        Task<IEnumerable<City>> GetByStateId(int stateId);
    }
}
