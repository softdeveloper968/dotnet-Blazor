using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IJobTitleRepository
    {
        Task<IEnumerable<JobTitle>> Get();
        Task<JobTitle> GetById(int id);
        Task<JobTitle> Add(JobTitle jobTitle);
    }
}
