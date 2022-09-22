using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContracts
{
  public interface IStateRepository
    {
        Task<IEnumerable<State>> Get();
        Task<State> GetById(int id);
    }
}
