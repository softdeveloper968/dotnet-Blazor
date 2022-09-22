using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IJobApplyRepository
    {
        Task<IEnumerable<JobApply>> Get();
        Task<JobApply> GetById(int id);
        Task<IEnumerable<JobApply>> GetByJobId(int id);
        Task<IEnumerable<JobApply>> GetByJobIdAndStatusId(int jobId,int statusId);
        Task<IEnumerable<JobApply>> GetByNurseId(string id);
        Task<IEnumerable<JobApply>> GetByStatusId(string nurseId,int statusId);
        Task<JobApply> Add(JobApply job);
        Task<JobApply> Update(JobApply job);
        Task Delete(JobApply job);
    }
}
