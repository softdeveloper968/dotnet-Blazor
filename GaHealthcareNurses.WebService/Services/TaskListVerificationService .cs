using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace Services
{
    public class TaskListVerificationService : ITaskListVerificationService
    {
        private ITaskListVerificationRepository _taskListVerificationRepository;
        private IMapper _mapper;

        #region Constructor for TaskListVerificationService
        public TaskListVerificationService(ITaskListVerificationRepository taskListVerificationRepository, IMapper mapper)
        {
            _taskListVerificationRepository = taskListVerificationRepository;
            _mapper = mapper;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<TaskListVerification>> Get()
        {
            return await _taskListVerificationRepository.Get();
        }

        public async Task<TaskListVerification> GetById(int id)
        {
            return await _taskListVerificationRepository.GetById(id);
        }

        public async Task<IEnumerable<TaskListVerification>> GetByJobId(int id)
        {
            return await _taskListVerificationRepository.GetByJobId(id);
        }
        public async Task<List<TaskListVerification>> GetByJobIdAndNurseId(int jobId, string nurseId)
        {
            return await _taskListVerificationRepository.GetByJobIdAndNurseId(jobId, nurseId);
        }


        public async Task<IEnumerable<TaskListVerification>> GetByNurseId(string id)
        {
            return await _taskListVerificationRepository.GetByNurseId(id);
        }

        public async Task<TaskListVerification> GetByDate(GetTaskListByDate getTaskListByDate)
        {
            return await _taskListVerificationRepository.GetByDate(getTaskListByDate);
        }


        public async Task<TaskListVerification> Add(TaskListVerification taskList)
        {
            return await _taskListVerificationRepository.Add(taskList);
        }

        public async Task Delete(TaskListVerification taskList)
        {
            await _taskListVerificationRepository.Delete(taskList);
        }

        public async Task<TaskListVerification> Update(TaskListVerification taskList)
        {
           return await _taskListVerificationRepository.Update(taskList);
        }
        #endregion
    }
}
