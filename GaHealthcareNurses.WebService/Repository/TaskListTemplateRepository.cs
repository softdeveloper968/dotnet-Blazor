using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class TaskListTemplateRepository : ITaskListTemplateRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For TaskListTemplateRepository
        public TaskListTemplateRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<TaskListTemplate> Add(TaskListTemplate taskListTemplate)
        {
            await _gaHealthcareNursesContext.TaskListTemplate.AddAsync(taskListTemplate);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskListTemplate;
        }

        public async Task<int> TotalCount(string filter,string id)
        {
            if (string.IsNullOrEmpty(filter))
                return await _gaHealthcareNursesContext.TaskListTemplate.Where(x=>x.EmployerId==id || x.EmployerId==null).CountAsync();

            return await _gaHealthcareNursesContext.TaskListTemplate.Where(x=>x.EmployerId==id || x.EmployerId==null).Where(x => x.TaskListCategory.Category.Contains(filter) || x.TaskName.Contains(filter)).CountAsync();
        }

        public async Task Delete(TaskListTemplate taskListTemplate)
        {
            _gaHealthcareNursesContext.TaskListTemplate.Remove(taskListTemplate);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskListTemplate>> Get(int skip, int take, string filter,string id)
        {
            if (filter != null)
            {
                var filteredRecords = await _gaHealthcareNursesContext.TaskListTemplate.Where(x=>x.EmployerId==id || x.EmployerId==null).Where(x => x.TaskListCategory.Category.Contains(filter) || x.TaskName.Contains(filter)).Include(x=>x.TaskListCategory).ToListAsync();
                return filteredRecords.Skip(skip).Take(take).ToList();
            }
            return await _gaHealthcareNursesContext.TaskListTemplate.Where(x=>x.EmployerId==id || x.EmployerId==null).Include(x => x.TaskListCategory).OrderByDescending(x => x.TaskListTemplateId).Skip(skip).Take(take).ToListAsync();
        }
        public async Task<IEnumerable<TaskListTemplate>> GetAll(string id)
        {
          return  await _gaHealthcareNursesContext.TaskListTemplate.Where(x => x.EmployerId == id || x.EmployerId == null).Include(x => x.TaskListCategory).ToListAsync();
        }

        public async Task<TaskListTemplate> GetById(int id)
        {
            return await _gaHealthcareNursesContext.TaskListTemplate.Where(x => x.TaskListTemplateId == id).FirstOrDefaultAsync();
        }

        public async Task<TaskListTemplate> Update(TaskListTemplate taskListTemplate)
        {
            _gaHealthcareNursesContext.TaskListTemplate.Update(taskListTemplate);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskListTemplate;
        }
        #endregion
    }
}
