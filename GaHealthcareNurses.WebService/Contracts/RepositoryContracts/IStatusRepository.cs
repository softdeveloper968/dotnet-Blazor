using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> Get();
        Task<IEnumerable<Status>> GetByTypeId(int id);
        Task<Status> GetById(int id);
        Task<Status> Add(Status status);
        Task Update(Status status);
        Task Delete(Status status);
    }
}
