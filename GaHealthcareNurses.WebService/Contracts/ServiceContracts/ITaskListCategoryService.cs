using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ITaskListCategoryService
    {
        Task<IEnumerable<TaskListCategory>> Get();
        Task<TaskListCategory> GetById(int id);
        Task<TaskListCategory> Add(TaskListCategory taskListCategory);
        Task<TaskListCategory> Update(TaskListCategory taskListCategory);
        Task Delete(TaskListCategory taskListCategory);
    }
}
