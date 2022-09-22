using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> Get();
        Task<IEnumerable<Status>> GetByTypeId(int id);
        Task<Status> GetById(int id);
        Task<Status> Add(Status status);
        Task Update(Status status);
        Task Delete(Status status);
    }
}
