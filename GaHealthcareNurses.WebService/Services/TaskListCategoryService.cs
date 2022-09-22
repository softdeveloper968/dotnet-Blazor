using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class TaskListCategoryService : ITaskListCategoryService
    {
        private ITaskListCategoryRepository _taskListCategoryRepository;

        #region Constructor for TaskListCategoryService
        public TaskListCategoryService(ITaskListCategoryRepository taskListCategoryRepository)
        {
            _taskListCategoryRepository = taskListCategoryRepository;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<TaskListCategory>> Get()
        {
            return await _taskListCategoryRepository.Get();
        }

        public async Task<TaskListCategory> GetById(int id)
        {
            return await _taskListCategoryRepository.GetById(id);
        }

        public async Task<TaskListCategory> Add(TaskListCategory taskListCategory)
        {
           return await _taskListCategoryRepository.Add(taskListCategory);
        }

        public async Task Delete(TaskListCategory taskListCategory)
        {
            await _taskListCategoryRepository.Delete(taskListCategory);
        }

        public async Task<TaskListCategory> Update(TaskListCategory taskListCategory)
        {
           return await _taskListCategoryRepository.Update(taskListCategory);
        }
        #endregion
    }
}
