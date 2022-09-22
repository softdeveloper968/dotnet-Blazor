using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> Get();
        Task <City> GetById(int id);
        Task <IEnumerable<City>> GetByStateId(int stateId);
    }
}
