using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TaskListCategoryRepository : ITaskListCategoryRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For TaskListCategoryRepository
        public TaskListCategoryRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<TaskListCategory> Add(TaskListCategory taskListCategory)
        {
            await _gaHealthcareNursesContext.TaskListCategory.AddAsync(taskListCategory);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskListCategory;
        }

        public async Task Delete(TaskListCategory taskListCategory)
        {
            _gaHealthcareNursesContext.TaskListCategory.Remove(taskListCategory);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskListCategory>> Get()
        {
            return await _gaHealthcareNursesContext.TaskListCategory.ToListAsync();
        }

        public async Task<TaskListCategory> GetById(int id)
        {
            return await _gaHealthcareNursesContext.TaskListCategory.Where(x => x.TaskListCategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<TaskListCategory> Update(TaskListCategory taskListCategory)
        {
            _gaHealthcareNursesContext.TaskListCategory.Update(taskListCategory);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskListCategory;
        }
        #endregion
    }
}
