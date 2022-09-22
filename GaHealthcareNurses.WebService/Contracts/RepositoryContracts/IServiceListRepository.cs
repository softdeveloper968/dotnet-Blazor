using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
  public interface IServiceListRepository
    {
        Task<IEnumerable<ServiceList>> Get();
        Task<ServiceList> GetById(int id);
    }
}
