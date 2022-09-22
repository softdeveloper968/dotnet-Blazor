using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRequiredServiceRepository
    {
        Task<IEnumerable<RequiredService>> Get();
        Task<RequiredService> GetById(int id);
        Task Add(RequiredService requiredService);
        Task Update(RequiredService requiredService);
        Task Delete(RequiredService requiredService);
    }
}
