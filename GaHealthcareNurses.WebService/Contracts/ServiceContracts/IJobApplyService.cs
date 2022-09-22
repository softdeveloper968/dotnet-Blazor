using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface IJobApplyService
    {
        Task<IEnumerable<JobApply>> Get();
        Task<JobApply> GetById(int id);
        Task<IEnumerable<JobApply>> GetByJobId(int id);
        Task<IEnumerable<JobApply>> GetByJobIdAndStatusId(int jobId, int statusId);
        Task<IEnumerable<JobApply>> GetByNurseId(string id);
        Task<IEnumerable<JobApply>> GetByStatusId(string nurseId, int statusId);
        Task<JobApply> Add(JobApply job);
        Task Delete(JobApply job);
        Task<JobApply> Update(JobApplyUpdateViewModel job);
        Task<JobApply> NurseFeedback(FeedbackViewModel nurseFeedback);
        Task<JobApply> ClientFeedback(FeedbackViewModel clientFeedback);
        Task<JobApply> PermissionForShareDocuments(PermissionToShareDocumentsViewModel permissionToShareDocuments);
        Task<JobApply> HireNurse(int id);
    }
}
