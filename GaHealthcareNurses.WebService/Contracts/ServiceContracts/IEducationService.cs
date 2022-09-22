using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IEducationService
    {
        Task<IEnumerable<Education>> Get();
        Task<Education> GetById(int id);
        Task Add(Education employer);
        Task Delete(Education employer);
        Task Update(Education employer);
    }
}
