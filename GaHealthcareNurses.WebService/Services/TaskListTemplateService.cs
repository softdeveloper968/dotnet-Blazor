using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class TaskListTemplateService : ITaskListTemplateService
    {
        private ITaskListTemplateRepository _taskListTemplateRepository;

        #region Constructor for TaskListTemplateService
        public TaskListTemplateService(ITaskListTemplateRepository taskListTemplateRepository)
        {
            _taskListTemplateRepository = taskListTemplateRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<TaskListTemplate>> Get(int skip, int take, string filter,string id)
        {
            return await _taskListTemplateRepository.Get(skip, take, filter,id);
        }

        public async Task<IEnumerable<TaskListTemplate>> GetAll(string id)
        {
            return await _taskListTemplateRepository.GetAll(id);
        }

        public async Task<int> TotalCount(string filter,string id)
        {
            return await _taskListTemplateRepository.TotalCount(filter,id);
        }

        public async Task<TaskListTemplate> GetById(int id)
        {
            return await _taskListTemplateRepository.GetById(id);
        }

        public async Task<TaskListTemplate> Add(TaskListTemplate taskListTemplate)
        {
            return await _taskListTemplateRepository.Add(taskListTemplate);
        }

        public async Task Delete(TaskListTemplate taskListTemplate)
        {
            await _taskListTemplateRepository.Delete(taskListTemplate);
        }

        public async Task<TaskListTemplate> Update(TaskListTemplate taskListTemplate)
        {
            return await _taskListTemplateRepository.Update(taskListTemplate);
        }
        #endregion
    }
}
