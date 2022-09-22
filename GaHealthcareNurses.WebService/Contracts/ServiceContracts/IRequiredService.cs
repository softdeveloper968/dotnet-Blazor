using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IRequiredService
    {
        Task<IEnumerable<RequiredService>> Get();
        Task<RequiredService> GetById(int id);
        Task Add(RequiredService requiredService);
        Task Delete(RequiredService requiredService);
        Task Update(RequiredService requiredService);
    }
}
