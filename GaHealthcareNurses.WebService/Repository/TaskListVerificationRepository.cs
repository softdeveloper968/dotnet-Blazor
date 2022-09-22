using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using GaHealthcareNurses.Entity.ViewModels;
using System;

namespace Repository
{
    public class TaskListVerificationRepository : ITaskListVerificationRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;

        #region Contructor For TaskListVerificationRepository
        public TaskListVerificationRepository(GaHealthcareNursesContext context)
        {
            _gaHealthcareNursesContext = context;
        }
        #endregion

        #region Implementing Interface
        public async Task<TaskListVerification> Add(TaskListVerification taskList)
        {
            await _gaHealthcareNursesContext.TaskListVerification.AddAsync(taskList);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskList;
        }

        public async Task Delete(TaskListVerification taskList)
        {
            _gaHealthcareNursesContext.TaskListVerification.Remove(taskList);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskListVerification>> Get()
        {
            return await _gaHealthcareNursesContext.TaskListVerification.Include(x => x.Job).Include(x => x.Nurse).ToListAsync();
        }

        public async Task<TaskListVerification> GetById(int id)
        {
            return await _gaHealthcareNursesContext.TaskListVerification.Where(x => x.TaskListVerificationId == id).Include(x => x.Job).Include(x => x.Nurse).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TaskListVerification>> GetByJobId(int id)
        {
            return await _gaHealthcareNursesContext.TaskListVerification.Where(x => x.JobId == id).Include(x => x.Job).Include(x => x.Nurse).ToListAsync();
        }

        public async Task<List<TaskListVerification>> GetByJobIdAndNurseId(int jobId, string nurseId)
        {
            return await _gaHealthcareNursesContext.TaskListVerification.Where(x => x.JobId == jobId && x.NurseId == nurseId).Include(x => x.Job).Include(x => x.Nurse).ToListAsync();
        }

        public async Task<IEnumerable<TaskListVerification>> GetByNurseId(string id)
        {
            return await _gaHealthcareNursesContext.TaskListVerification.Where(x => x.NurseId == id).Include(x => x.Job).Include(x => x.Nurse).ToListAsync();
        }

        public async Task<TaskListVerification> GetByDate(GetTaskListByDate getTaskListByDate)
        {
            return await _gaHealthcareNursesContext.TaskListVerification.Where(x => x.TaskDate == Convert.ToDateTime(getTaskListByDate.Date).ToShortDateString() && x.JobId == getTaskListByDate.JobId && x.NurseId == getTaskListByDate.NurseId).Include(x => x.Job).Include(x => x.Nurse).FirstOrDefaultAsync();
        }

        public async Task<TaskListVerification> Update(TaskListVerification taskList)
        {
            _gaHealthcareNursesContext.TaskListVerification.Update(taskList);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskList;
        }
        #endregion
    }
}
