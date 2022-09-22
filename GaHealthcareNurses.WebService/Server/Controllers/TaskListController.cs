using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _taskListService;
        private readonly IMapper _mapper;
        public TaskListController(ITaskListService taskListService, IMapper mapper)
        {
            _taskListService = taskListService;
            _mapper = mapper;
        }


        // GET: api/TaskList/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var taskList = await _taskListService.Get();
                return new JsonResult(new Response<IEnumerable<TaskList>> { Status = "Success", Data = taskList });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskList/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var task = await _taskListService.GetById(id);
                if (task == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid tasklist id" });

                return new JsonResult(new Response<TaskList> { Status = "Success", Data = task });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskList/GetByJobId
        [HttpGet]
        [Route("GetByJobId")]
        public async Task<IActionResult> GetByJobId(int id)
        {
            try
            {
                var taskList = await _taskListService.GetByJobId(id);
                if (taskList == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id" });

                return new JsonResult(new Response<IEnumerable<TaskList>> { Status = "Success", Data = taskList });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskList/GetByNurseId
        [HttpGet]
        [Route("GetByNurseId")]
        public async Task<IActionResult> GetByNurseId(string id)
        {
            try
            {
                var taskList = await _taskListService.GetByNurseId(id);
                if (taskList == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid nurse id" });

                return new JsonResult(new Response<IEnumerable<TaskList>> { Status = "Success", Data = taskList });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskList/GetByDate
        [HttpPost]
        [Route("GetByDate")]
        public async Task<IActionResult> GetByDate(GetTaskListByDate getTaskListByDate)
        {
            try
            {
                var taskList = await _taskListService.GetByDate(getTaskListByDate);
                if (taskList == null || taskList.ToList().Count == 0)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Please enter valid details and try again." });

                return new JsonResult(new Response<IEnumerable<TaskList>> { Status = "Success", Data = taskList });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        //// GET: api/TaskList/GetTaskStatus
        //[HttpPost]
        //[Route("GetTaskStatus")]
        //public async Task<IActionResult> GetTaskStatus(GetTaskListByDate getTaskListByDate)
        //{
        //    var taskList = await _taskListService.GetByDate(getTaskListByDate);
        //    if (taskList == null || taskList.ToList().Count == 0)
        //        return new JsonResult(new Response<string> { Status = "Error", Message = "Please enter valid details and try again." });

        //    foreach (var task in taskList)
        //    {
        //        if (!task.TaskStatus)
        //            return new JsonResult(new Response<IEnumerable<TaskList>> { Status = "Success", Message = "All Tasks are not completed for the day.", Data = taskList });
        //    }

        //    return new JsonResult(new Response<IEnumerable<TaskList>> { Status = "Success", Message = "All Tasks are completed for the day.", Data = taskList });
        //}


        // GET: api/TaskList/GetByJobIdAndNurseId
        [HttpGet]
        [Route("GetByJobIdAndNurseId")]
        public async Task<IActionResult> GetByJobIdAndNurseId(int jobId, string nurseId)
        {
            try
            {
                var taskList = await _taskListService.GetByJobIdAndNurseId(jobId, nurseId);
                if (taskList == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id" });
                //foreach (var task in taskList.ToList())
                //{
                //    if (task.Date.Date != DateTime.UtcNow.Date)
                //    {
                //        taskList.Remove(task);
                //    }
                //}

                return new JsonResult(new Response<List<TaskList>> { Status = "Success", Data = taskList });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        // GET: api/TaskList/GetTaskListForHiredNurse
        [HttpGet]
        [Route("GetTaskListForHiredNurse")]
        public async Task<object> GetTaskListForHiredNurse(int jobId, string nurseId)
        {
            try
            {
                int count = await _taskListService.TotalCount(string.Empty, jobId,nurseId);
                var queryString = Request.Query;
                string sort = queryString["$orderby"];   //sorting      
                string filter = queryString["$filter"];
                string auto = queryString["$inlineCount"];

                StringValues Skip;
                StringValues Take;
                StringValues Filter;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                string filterValue = (queryString.TryGetValue("$filter", out Filter)) ? Convert.ToString(Filter[0])?.Split('\'')[1] : null;
                if (filterValue != null)
                {
                    count = await _taskListService.TotalCount(filterValue, jobId,nurseId);
                }
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : count;
                var taskList = await _taskListService.GetTaskListForHiredNurse(skip, top, filterValue, jobId,nurseId);

                if (taskList == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
                }

                return new { Items = taskList, Count = count };
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskList/GetTaskListCalender
        [HttpGet]
        [Route("GetTaskListCalender")]
        public async Task<IActionResult> GetTaskListCalender(int jobId, string nurseId)
        {
            try
            {
                var taskListCalender = await _taskListService.GetTaskListCalender(jobId, nurseId);
                if (taskListCalender == null || taskListCalender.Count == 0)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Please enter valid id's and try again." });

                return new JsonResult(new Response<List<TaskListCalender>> { Status = "Success", Data = taskListCalender });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // POST: api/TaskList/Add
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTaskListViewModel taskList)
        {
            try
            {
                if (taskList == null)
                    return BadRequest("TaskList is null");
                await _taskListService.Add(taskList);
                return new JsonResult(new Response<string> { Status = "Success", Message = "Tasklist assigned!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // DELETE: api/TaskList/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _taskListService.DeleteTaskList(id);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Tasklist Cleared!" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });

            }

        }


        //PUT: api/TaskList/Update
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Put(TaskListViewModel taskListViewModel)
        {
            try
            {
                if (taskListViewModel == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Task is null" });
                }

                var taskList = _mapper.Map<TaskList>(taskListViewModel);

                var task = await _taskListService.Update(taskList);
                if (task != null)
                    return new JsonResult(new Response<TaskList> { Status = "Success", Message = "Task Updated Successfully!", Data = task });
                else
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        //PUT: api/TaskList/TaskStatusForDay
        [Route("TaskStatusForDay")]
        [HttpPost]
        public async Task<IActionResult> TaskStatusForDay([FromForm] AddSignatureViewModel addSignatureViewModel)
        {
            try
            {
                if (addSignatureViewModel == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Signature is null" });

                var taskListVerificationData = await _taskListService.AddSignature(addSignatureViewModel);

                if (!string.IsNullOrEmpty(taskListVerificationData.Signature))
                    return new JsonResult(new Response<TaskListVerification> { Status = "Success", Message = "Day is completed for a nurse." });

                return new JsonResult(new Response<TaskListVerification> { Status = "Error", Message = "Day is not completed for a nurse." });

            }

            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


    }
}
