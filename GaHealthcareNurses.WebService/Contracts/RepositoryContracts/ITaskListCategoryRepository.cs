using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITaskListCategoryRepository
    {
        Task<IEnumerable<TaskListCategory>> Get();
        Task<TaskListCategory> GetById(int id);
        Task<TaskListCategory> Add(TaskListCategory taskListCategory);
        Task<TaskListCategory> Update(TaskListCategory taskListCategory);
        Task Delete(TaskListCategory taskListCategory);
    }
}
