using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ITaskListService
    {
        Task<IEnumerable<TaskList>> Get();
        Task<TaskList> GetById(int id);
        Task<int> TotalCount(string filter, int jobId,string nurseId);
        Task<IEnumerable<TaskList>> GetByJobId(int id);
        Task<IEnumerable<TaskList>> GetByNurseId(string id);
        Task<IEnumerable<TaskList>> GetByDate(GetTaskListByDate getTaskListByDate);
        Task<List<TaskListCalender>> GetTaskListCalender(int jobId, string nurseId);
        Task<List<TaskList>> GetByJobIdAndNurseId(int jobId, string nurseId);
        Task<List<TaskList>> GetTaskListForHiredNurse(int skip, int take, string filter, int jobId, string nurseId);
        Task Add(AddTaskListViewModel taskList);
        Task Delete(TaskList taskList);
        Task<TaskList> Update(TaskList taskList);
        Task<TaskListVerification> AddSignature(AddSignatureViewModel addSignatureViewModel);
        Task DeleteTaskList(int jobId);
    }
}
