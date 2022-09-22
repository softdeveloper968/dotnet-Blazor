using Contracts;
using GaHealthcareNurses.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.Entity.Models;
using Microsoft.EntityFrameworkCore;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using Contracts.ServiceContracts;

namespace Repository
{
    public class TaskListRepository : ITaskListRepository
    {
        private GaHealthcareNursesContext _gaHealthcareNursesContext;
        private ITaskListVerificationService _taskListVerificationService;

        #region Contructor For TaskListRepository
        public TaskListRepository(GaHealthcareNursesContext context, ITaskListVerificationService taskListVerificationService)
        {
            _gaHealthcareNursesContext = context;
            _taskListVerificationService = taskListVerificationService;
        }
        #endregion

        #region Implementing Interface
        public async Task<TaskList> Add(TaskList taskList)
        {
            await _gaHealthcareNursesContext.TaskList.AddAsync(taskList);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            var taskListVerificationData=  await _gaHealthcareNursesContext.TaskListVerification.Where(x=>x.JobId==taskList.JobId && x.NurseId==taskList.NurseId && x.TaskDate == taskList.Date.Date.ToShortDateString()).FirstOrDefaultAsync();
            if (taskListVerificationData == null) {
                TaskListVerification taskListVerification = new TaskListVerification();
                taskListVerification.JobId = taskList.JobId;
                taskListVerification.NurseId = taskList.NurseId;
                taskListVerification.TaskDate = taskList.Date.Date.ToShortDateString();
                await  _taskListVerificationService.Add(taskListVerification);
            }
            return taskList;
        }

        public async Task<int> TotalCount(string filter,int jobId, string nurseId)
        {
            if (string.IsNullOrEmpty(filter))
                return await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == jobId && x.NurseId == nurseId).CountAsync();

            return await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == jobId && x.NurseId == nurseId).Where(x => x.TaskName.Contains(filter)).CountAsync();
        }

        public async Task Delete(TaskList taskList)
        {
            _gaHealthcareNursesContext.TaskList.Remove(taskList);
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task DeleteTaskList(int jobId)
        {
           var taskList= await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == jobId).ToListAsync();
            foreach(var task in taskList)
            {
               _gaHealthcareNursesContext.TaskList.Remove(task);
            }
            await _gaHealthcareNursesContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskList>> Get()
        {
            return await _gaHealthcareNursesContext.TaskList.Include(x => x.Job).Include(x => x.Nurse).Include(x => x.VisitNote).ToListAsync();
        }

        public async Task<TaskList> GetById(int id)
        {
            return await _gaHealthcareNursesContext.TaskList.Where(x => x.TaskListId == id).Include(x => x.Job).Include(x => x.Nurse).Include(x => x.VisitNote).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TaskList>> GetByJobId(int id)
        {
            return await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == id).Include(x => x.Job).Include(x => x.Nurse).Include(x => x.VisitNote).ToListAsync();
        }

        public async Task<List<TaskList>> GetByJobIdAndNurseId(int jobId, string nurseId)
        {
            return await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == jobId && x.NurseId == nurseId).Include(x => x.Job).Include(x => x.Nurse).Include(x => x.VisitNote).ToListAsync();
        }

        public async Task<IEnumerable<TaskList>> GetByNurseId(string id)
        {
            return await _gaHealthcareNursesContext.TaskList.Where(x => x.NurseId == id).Include(x => x.Job).Include(x => x.Nurse).Include(x => x.VisitNote).ToListAsync();
        }


        public async Task<List<TaskList>> GetTaskListForHiredNurse(int skip, int take, string filter,int jobId ,string nurseId)
        {
            if (filter != null)
            {
                var filteredRecords = await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == jobId && x.NurseId == nurseId).Where(x => x.TaskName.Contains(filter)).Include(x => x.Nurse).Include(x=>x.Job).ToListAsync();
                return filteredRecords.Skip(skip).Take(take).ToList();
            }
            return await _gaHealthcareNursesContext.TaskList.Where(x => x.JobId == jobId && x.NurseId == nurseId).Include(x => x.Nurse).Include(x => x.Job).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<IEnumerable<TaskList>> GetByDate(GetTaskListByDate getTaskListByDate)
        {
            return await _gaHealthcareNursesContext.TaskList.Where(x => x.Date.Date == Convert.ToDateTime(getTaskListByDate.Date) && x.JobId == getTaskListByDate.JobId && x.NurseId == getTaskListByDate.NurseId).Include(x => x.Job).Include(x => x.Nurse).Include(x => x.VisitNote).ToListAsync();
        }

        public async Task<TaskList> Update(TaskList taskList)
        {
            _gaHealthcareNursesContext.TaskList.Update(taskList);
            await _gaHealthcareNursesContext.SaveChangesAsync();
            return taskList;
        }
        #endregion
    }
}
