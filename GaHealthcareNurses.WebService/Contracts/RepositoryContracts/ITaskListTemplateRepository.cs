using GaHealthcareNurses.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITaskListTemplateRepository
    {
        Task<IEnumerable<TaskListTemplate>> Get(int skip, int take, string filter,string id);
        Task<IEnumerable<TaskListTemplate>> GetAll(string id);
        Task<int> TotalCount(string filter,string id);
        Task<TaskListTemplate> GetById(int id);
        Task<TaskListTemplate> Add(TaskListTemplate taskListTemplate);
        Task<TaskListTemplate> Update(TaskListTemplate taskListTemplate);
        Task Delete(TaskListTemplate taskListTemplate);
    }
}
