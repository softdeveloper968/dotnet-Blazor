using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ITaskListVerificationService
    {
        Task<IEnumerable<TaskListVerification>> Get();
        Task<TaskListVerification> GetById(int id);
        Task<IEnumerable<TaskListVerification>> GetByJobId(int id);
        Task<IEnumerable<TaskListVerification>> GetByNurseId(string id);
        Task<TaskListVerification> GetByDate(GetTaskListByDate getTaskListByDate);
        Task<List<TaskListVerification>> GetByJobIdAndNurseId(int jobId, string nurseId);
        Task<TaskListVerification> Add(TaskListVerification taskList);
        Task<TaskListVerification> Update(TaskListVerification taskList);
        Task Delete(TaskListVerification taskList);
    }
}
