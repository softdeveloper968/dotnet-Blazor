using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using Services.Helper;

namespace Services
{
    public class TaskListService : ITaskListService
    {
        private ITaskListRepository _taskListRepository;
        private ITaskListVerificationService _taskListVerificationService;
        private IJobApplyService _jobApplyService;

        private IMapper _mapper;

        #region Constructor for TaskListService
        public TaskListService(ITaskListRepository taskListRepository, IMapper mapper, ITaskListVerificationService taskListVerificationService, IJobApplyService jobApplyService)
        {
            _taskListRepository = taskListRepository;
            _mapper = mapper;
            _taskListVerificationService = taskListVerificationService;
            _jobApplyService = jobApplyService;
        }
        #endregion

        #region Implementing Interface
        public async Task<IEnumerable<TaskList>> Get()
        {
            return await _taskListRepository.Get();
        }

        public async Task<int> TotalCount(string filter,int jobId, string nurseId)
        {
            return await _taskListRepository.TotalCount(filter, jobId,nurseId);
        }

        public async Task<List<TaskList>> GetTaskListForHiredNurse(int skip, int take, string filter, int jobId, string nurseId)
        {
            return await _taskListRepository.GetTaskListForHiredNurse(skip, take, filter, jobId, nurseId);
        }

        public async Task<TaskList> GetById(int id)
        {
            return await _taskListRepository.GetById(id);
        }

        public async Task<IEnumerable<TaskList>> GetByJobId(int id)
        {
            return await _taskListRepository.GetByJobId(id);
        }
        public async Task<List<TaskList>> GetByJobIdAndNurseId(int jobId, string nurseId)
        {
            return await _taskListRepository.GetByJobIdAndNurseId(jobId, nurseId);
        }

        //public async Task<List<TaskListCalender>> GetTaskListCalender(int jobId, string nurseId)
        //{
        //    var tasks = await _taskListRepository.GetTaskListCalender(jobId, nurseId);
        //    var tasksByDate = tasks.GroupBy(x => x.Date.Date);
        //    List<TaskListCalender> taskList = new List<TaskListCalender>();
        //    foreach (var task in tasksByDate)
        //    {
        //        TaskListCalender taskListCalender = new TaskListCalender();
        //        foreach (var item in task)
        //        {
        //            taskListCalender.Date = item.Date.Date.ToShortDateString();
        //            if (!item.TaskStatus)
        //            {
        //                taskListCalender.Completed = false;
        //                break;
        //            }
        //            taskListCalender.Completed = item.TaskStatus;
        //        }
        //        taskList.Add(taskListCalender);
        //    }

        //    //return await _taskListRepository.GetTaskListCalender(jobId, nurseId);
        //    return taskList;

        //}

        public async Task<List<TaskListCalender>> GetTaskListCalender(int jobId, string nurseId)
        {
            List<TaskListCalender> taskList = new List<TaskListCalender>();
            var tasks = await _taskListVerificationService.GetByJobIdAndNurseId(jobId, nurseId);
            foreach (var task in tasks)
            {
                TaskListCalender taskListCalender = new TaskListCalender();
                taskListCalender.Date = task.TaskDate;
                if (string.IsNullOrEmpty(task.Signature))
                    taskListCalender.Completed = false;
                else
                    taskListCalender.Completed = true;

                taskList.Add(taskListCalender);
            }
            return taskList;
        }

        public async Task<IEnumerable<TaskList>> GetByNurseId(string id)
        {
            return await _taskListRepository.GetByNurseId(id);
        }

        public async Task<IEnumerable<TaskList>> GetByDate(GetTaskListByDate getTaskListByDate)
        {
            return await _taskListRepository.GetByDate(getTaskListByDate);
        }


        public async Task Add(AddTaskListViewModel addTaskList)
        {
            Nurse nurse = new Nurse();
            Job job = new Job();
            var jobApplied = await _jobApplyService.GetByJobIdAndStatusId(addTaskList.JobId, 1);
            foreach (var jobApply in jobApplied)
            {
                nurse.Id = jobApply.NurseId;
                job = jobApply.Job;
            }

            for(DateTime date = Convert.ToDateTime(job.CareRecipient.WhenToStart); date.Date <= Convert.ToDateTime(job.CareRecipient.EndDate); date = date.AddDays(1))
            {
                string[] weekDays = job.CareRecipient.Frequency.Split(",");

                foreach (var day in weekDays)
                {
                    if (date.DayOfWeek.ToString() != day.TrimEnd())
                    {
                        continue;
                    }

                    foreach (var task in addTaskList.TaskListAddTemplates)
                    {
                        TaskList taskList = new TaskList
                        {
                            NurseId = nurse.Id,
                            JobId = addTaskList.JobId,
                            EmployerId = addTaskList.EmployerId,
                            TaskName = task.TaskName,
                            TaskDescription = task.TaskDescription,
                            Date = date
                        };
                        await _taskListRepository.Add(taskList);
                    }
                    break;
                }

            }

        }

        public async Task Delete(TaskList taskList)
        {
            await _taskListRepository.Delete(taskList);
        }

        public async Task DeleteTaskList(int jobId)
        {
            await _taskListRepository.DeleteTaskList(jobId);
        }

        public async Task<TaskList> Update(TaskList taskList)
        {
            if (!string.IsNullOrEmpty(taskList.StartTime) && !string.IsNullOrEmpty(taskList.EndTime))
            {
                taskList.TotalTime = Convert.ToDateTime(taskList.EndTime).Subtract(Convert.ToDateTime(taskList.StartTime)).ToString();
            }
            return await _taskListRepository.Update(taskList);
        }

        //public async Task AddSignature(AddSignatureViewModel addSignatureViewModel)
        //{
        //    var getTaskListByDate = _mapper.Map<GetTaskListByDate>(addSignatureViewModel);

        //    TaskListVerification taskListVerificationData = new TaskListVerification();

        //    var taskListByDate = await _taskListRepository.GetByDate(getTaskListByDate);
        //    foreach (var task in taskListByDate)
        //    {
        //        if (task.TaskStatus == true)
        //        {
        //            taskListVerificationData = await _taskListVerificationService.GetByDate(getTaskListByDate);
        //            break;
        //        }
        //    }
        //    if (taskListVerificationData.TaskListVerificationId != 0)
        //    {
        //        if (addSignatureViewModel.Signature != null)
        //        {
        //            var signaturePath = UploadAndDownloadFileAzure.UploadDocument(addSignatureViewModel.Signature, addSignatureViewModel.NurseId);
        //            taskListVerificationData.Signature = signaturePath;
        //            var taskList = await _taskListVerificationService.Update(taskListVerificationData);
        //        }
        //    }

        //}


        public async Task<TaskListVerification> AddSignature(AddSignatureViewModel addSignatureViewModel)
        {
            var getTaskListByDate = _mapper.Map<GetTaskListByDate>(addSignatureViewModel);

            var taskListVerificationData = await _taskListVerificationService.GetByDate(getTaskListByDate);

            if (taskListVerificationData != null)
            {
                if (addSignatureViewModel.Signature != null)
                {
                    var signaturePath = UploadAndDownloadFileAzure.UploadDocument(addSignatureViewModel.Signature, $"{addSignatureViewModel.NurseId}/Signature/{taskListVerificationData.TaskListVerificationId}");
                    taskListVerificationData.Signature = signaturePath;
                    taskListVerificationData.Latitude = addSignatureViewModel.Latitude;
                    taskListVerificationData.Longitude = addSignatureViewModel.Longitude;
                    if (addSignatureViewModel.TaskVerifiedTime != null)
                        taskListVerificationData.TaskVerifiedTime = addSignatureViewModel.TaskVerifiedTime;
                    await _taskListVerificationService.Update(taskListVerificationData);
                }
            }
            return taskListVerificationData;
        }

        #endregion
    }
}
