using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IJobRepository
    {
        //  Task<GetJobsForAgencyViewModel> GetJobsForAgency(PaginationFilter paginationFilter);
        Task<IEnumerable<Job>> GetJobsForAgency(int skip,int take,string filter);
        Task<int> TotalCount(string filter);
        Task<IEnumerable<Job>> Get(PaginationFilter paginationFilter);
        Task<Job> GetById(int id);
        Task<IEnumerable<Job>> GetByClientId(string id);
        Task<Job> Add(Job job);
        Task Update(Job job);
        Task Delete(Job job);
    }
}
