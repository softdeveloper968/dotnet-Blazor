using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IJobTitleService
    {
        Task<IEnumerable<JobTitle>> Get();
        Task<JobTitle> GetById(int id);
        Task<JobTitle> Add(JobTitle jobTitle);
    }
}
