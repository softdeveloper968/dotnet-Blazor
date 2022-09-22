using Contracts;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Services
{
    public class WorkHistoryService : IWorkHistoryService
    {
        private readonly ITaskListService _taskListService;
        private readonly IJobApplyService _jobApplyService;

        #region Constructor for WorkHistoryService
        public WorkHistoryService(ITaskListService taskListService, IJobApplyService jobApplyService)
        {
            _taskListService = taskListService;
            _jobApplyService = jobApplyService;
        }
        #endregion

        #region Implementing Interface
        public async Task<List<WorkHistoryResponseModel>> GetWorkHistory(WorkHistoryViewModel workHistoryViewModel)
        {
            List<WorkHistoryResponseModel> workHistoryData = new List<WorkHistoryResponseModel>();

            if (workHistoryViewModel.StartingDate != null && workHistoryViewModel.EndingDate != null)
            {
                for (DateTime date = Convert.ToDateTime(workHistoryViewModel.StartingDate); date.Date <= Convert.ToDateTime(workHistoryViewModel.EndingDate); date = date.AddDays(1))
                {
                    var workingMinutes = 0.0;
                    WorkHistoryResponseModel workHistoryResponseModel = new WorkHistoryResponseModel();
                    workHistoryResponseModel.Date = date.Date.ToShortDateString();
                    GetTaskListByDate getTaskListByDate = new GetTaskListByDate();
                    getTaskListByDate.Date = date.Date.ToString();
                    getTaskListByDate.NurseId = workHistoryViewModel.NurseId;
                    getTaskListByDate.JobId = workHistoryViewModel.JobId;

                    var workHistoryResponse = await _taskListService.GetByDate(getTaskListByDate);
                    foreach (var workHistory in workHistoryResponse)
                    {
                        if (!string.IsNullOrEmpty(workHistory.TotalTime))
                        {
                            double minutes = TimeSpan.Parse(workHistory.TotalTime).TotalMinutes;
                            workingMinutes += minutes;
                        }
                    }
                    var time = TimeSpan.FromMinutes(workingMinutes);
                    workHistoryResponseModel.Hours = string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
                    workHistoryData.Add(workHistoryResponseModel);
                }

                return workHistoryData;
            }

            var workHistoryForNurse = await _taskListService.GetByJobIdAndNurseId(workHistoryViewModel.JobId, workHistoryViewModel.NurseId);
            var workHistoryByDate = workHistoryForNurse.GroupBy(x => x.Date.Date);

            foreach (var workHistory in workHistoryByDate)
            {
                var workingMinutes = 0.0;
                WorkHistoryResponseModel workHistoryResponseModel = new WorkHistoryResponseModel();
                foreach (var item in workHistory)
                {
                    workHistoryResponseModel.Date = item.Date.ToShortDateString();
                    if (!string.IsNullOrEmpty(item.TotalTime))
                    {
                        double minutes = TimeSpan.Parse(item.TotalTime).TotalMinutes;
                        workingMinutes += minutes;
                    }
                }
                var time = TimeSpan.FromMinutes(workingMinutes);
                workHistoryResponseModel.Hours = string.Format("{0:00}:{1:00}", (int)time.TotalHours, time.Minutes);
                workHistoryData.Add(workHistoryResponseModel);
            }
            return workHistoryData;
        }

        public async Task<IEnumerable<NurseWorkHistoryViewModel>> GetWorkHistoryForNurse(string id)
        {
            var statusId = 7;
            var workHistory= await _jobApplyService.GetByStatusId(id, statusId);
            List<NurseWorkHistoryViewModel> nurseWorkHistory = new List<NurseWorkHistoryViewModel>();
            foreach(var work in workHistory)
            {
                NurseWorkHistoryViewModel nurseWorkHistoryViewModel = new NurseWorkHistoryViewModel();
                nurseWorkHistoryViewModel.ClientFirstName = work.Job.Client.FirstName;
                nurseWorkHistoryViewModel.ClientLastName = work.Job.Client.LastName;
                nurseWorkHistoryViewModel.ClientMiddleInitial = work.Job.Client.MiddleInitial;
                nurseWorkHistoryViewModel.JobTitle = work.Job.JobTitle.Title;
                nurseWorkHistoryViewModel.JobDescription = work.Job.Description;
                nurseWorkHistoryViewModel.Location = work.Job.CareRecipient.City.Name;
                nurseWorkHistoryViewModel.ClientFeedBack = work.ClientFeedback;
                nurseWorkHistoryViewModel.ClientRating = work.ClientRating;
                nurseWorkHistoryViewModel.NurseFeedBack = work.NurseFeedback;
                nurseWorkHistoryViewModel.NurseRating = work.NurseRating;
                nurseWorkHistory.Add(nurseWorkHistoryViewModel);
            }
            return nurseWorkHistory;
        }
        #endregion
    }
}
