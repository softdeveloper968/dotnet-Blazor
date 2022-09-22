using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.ServiceContracts
{
    public interface ITaskListTemplateService
    {
        Task<IEnumerable<TaskListTemplate>> Get(int skip, int take, string filter, string id);
        Task<IEnumerable<TaskListTemplate>> GetAll(string id);
        Task<int> TotalCount(string filter,string id);
        Task<TaskListTemplate> GetById(int id);
        Task<TaskListTemplate> Add(TaskListTemplate taskListTemplate);
        Task<TaskListTemplate> Update(TaskListTemplate taskListTemplate);
        Task Delete(TaskListTemplate taskListTemplate);
    }
}
