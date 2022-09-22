using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplyController : ControllerBase
    {
        private readonly IJobApplyService _jobApplyService;
        private readonly IMapper _mapper;
        public readonly INurseService _nurseService;
        private readonly IPushNotificationService _pushNotificationService;

        public JobApplyController(IJobApplyService jobApplyService, IMapper mapper,INurseService nurseService,IPushNotificationService pushNotificationService)
        {
            _jobApplyService = jobApplyService;
            _mapper = mapper;
            _nurseService = nurseService;
            _pushNotificationService = pushNotificationService;
        }


        //// GET: api/JobApply/GetAll

        //[HttpGet]
        //[Route("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    try
        //    {
        //        var jobsApplied = await _jobApplyService.Get();
        //        return new JsonResult(new Response<IEnumerable<JobApply>> { Status = "Success", Data = jobsApplied });
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
        //    }
        //}

        // GET: api/JobApply/GetByJobId
        [HttpGet]
        [Route("GetByJobId")]
        public async Task<IActionResult> GetByJobId(int id)
        {
            var jobsApplied = await _jobApplyService.GetByJobId(id);
            if (jobsApplied == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id" });

            return new JsonResult(new Response<IEnumerable<JobApply>> { Status = "Success", Data = jobsApplied });
        }


        // GET: api/JobApply/GetByNurseId
        [HttpGet]
        [Route("GetByNurseId")]
        public async Task<IActionResult> GetByNurseId(string id)
        {
            var jobsApplied = await _jobApplyService.GetByNurseId(id);
            if (jobsApplied == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid nurse id" });

            return new JsonResult(new Response<IEnumerable<JobApply>> { Status = "Success", Data = jobsApplied });
        }

        // GET: api/JobApply/GetByStatusId
        [HttpGet]
        [Route("GetByStatusId")]
        public async Task<IActionResult> GetByStatusId(string nurseId,int statusId)
        {
            var jobsApplied = await _jobApplyService.GetByStatusId(nurseId,statusId);
            if (jobsApplied == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid nurse id" });

            return new JsonResult(new Response<IEnumerable<JobApply>> { Status = "Success", Data = jobsApplied });
        }

        // GET: api/JobApply/GetByJobIdAndStatusId
        [HttpGet]
        [Route("GetByJobIdAndStatusId")]
        public async Task<IActionResult> GetByJobIdAndStatusId(int jobId, int statusId)
        {
            var jobsApplied = await _jobApplyService.GetByJobIdAndStatusId(jobId, statusId);
            if (jobsApplied == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id" });

            return new JsonResult(new Response<IEnumerable<JobApply>> { Status = "Success", Data = jobsApplied });
        }



        // GET: api/JobApply/GetHiredNurses
        [HttpGet]
        [Route("GetHiredNurses")]
        public async Task<object> GetHiredNurses(int jobId,int statusId)
        {
            var jobsApplied = await _jobApplyService.GetByJobIdAndStatusId(jobId, statusId);
            if (jobsApplied == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id" });

            return new { items = jobsApplied };
        }

        // GET: api/JobApply/HireNurse
        [HttpGet]
        [Route("HireNurse")]
        public async Task<IActionResult> HireNurse(int id)
        {
            var job = await _jobApplyService.HireNurse(id);
            if (job != null)
            {
                var dataObj = new
                {
                    title = job.Job.JobTitle.Title,
                    body = job.Job.Description,
                    sound = "default",
                    messageType = "New Job Offer"
                };

                var dataWrapper = new { data = dataObj };
                var nurse = await _nurseService.GetById(job.Nurse.Id);
                
                    if (!string.IsNullOrEmpty(nurse.FirebaseToken))
                    {
                        if (nurse.IsUserAvailableForJob)
                        {
                            bool status = await _pushNotificationService.SendNotification(new
                            {
                                //to = "d9KonoX9IhQ:APA91bE2h7_2ekOI3j6oJQwcesI03U9xoVp8txPx5R0bN7COixxBSEgQUEMurK9IzW_k9zccG561QQr2AgN22PUrvhE6IyfGEkZK3iLbIv4tZz-ZUqsY6Sd8fGb8QlHswYus4VJHmqcU",
                                priority = "high",
                                to = nurse.FirebaseToken,
                                notification = dataObj
                            });
                    }
                }
                return new JsonResult(new Response<JobApply> { Status = "Success", Data = job });
            }  

            return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
        }



        // GET: api/JobApply/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobApply = await _jobApplyService.GetById(id);
            if (jobApply == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid jobApply id" });

            return new JsonResult(new Response<JobApply> { Status = "Success", Data = jobApply });
        }

        // POST: api/JobApply/Post
        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobApplyViewModel jobApply)
        {
            try
            {
                if (jobApply == null)
                    return BadRequest("JobApply is null");

                var jobs = _mapper.Map<JobApply>(jobApply);

                var jobApplied = await _jobApplyService.Add(jobs);

                if (jobApplied == null)
                    return new JsonResult(new Response<JobApply> { Status = "Error", Message = "Job apply failed! Please check job details and try again." });

                return new JsonResult(new Response<JobApply> { Status = "Success", Message = "Job applied successfully!", Data = jobApplied });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        //PUT: api/JobApply/Update
       [Route("Update")]
       [HttpPut]
        public async Task<IActionResult> Put([FromBody] JobApplyUpdateViewModel jobApply)
        {
            try
            {
                if (jobApply == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "JobApply is null" });
                }
                // var jobs = _mapper.Map<JobApply>(jobApply);
                var jobApplied=   await _jobApplyService.Update(jobApply);
                if(jobApplied != null)
                return new JsonResult(new Response<JobApply> { Status = "Success",Data= jobApplied });

                    return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // POST: api/JobApply/NurseFeedback
        [Route("NurseFeedback")]
        [HttpPost]
        public async Task<IActionResult> NurseFeedback([FromBody] FeedbackViewModel nurseFeedbackViewModel)
        {
            try
            {
                if (nurseFeedbackViewModel == null)
                    return BadRequest("Nurse feedback is null");

               var nurseFeedback= await _jobApplyService.NurseFeedback(nurseFeedbackViewModel);

                if (nurseFeedback == null)
                    return new JsonResult(new Response<JobApply> { Status = "Error", Message = "Please check details and try again." });

                return new JsonResult(new Response<JobApply> { Status = "Success", Message = "Nurse feedback posted successfully!", Data = nurseFeedback });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        // POST: api/JobApply/ClientFeedback
        [Route("ClientFeedback")]
        [HttpPost]
        public async Task<IActionResult> ClientFeedback([FromBody] FeedbackViewModel clientFeedbackViewModel)
        {
            try
            {
                if (clientFeedbackViewModel == null)
                    return BadRequest("Client feedback is null");

                var clientFeedback = await _jobApplyService.ClientFeedback(clientFeedbackViewModel);

                if (clientFeedback == null)
                    return new JsonResult(new Response<JobApply> { Status = "Error", Message = "Please check details and try again." });

                return new JsonResult(new Response<JobApply> { Status = "Success", Message = "Client feedback posted successfully!", Data = clientFeedback });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // POST: api/JobApply/PermissionForShareDocuments
        [Route("PermissionForShareDocuments")]
        [HttpPost]
        public async Task<IActionResult> PermissionForShareDocuments([FromBody] PermissionToShareDocumentsViewModel permissionToShareDocuments)
        {
            try
            {
                if (permissionToShareDocuments == null)
                    return BadRequest("Documents are null");

                var documents = await _jobApplyService.PermissionForShareDocuments(permissionToShareDocuments);

                if (documents == null)
                    return new JsonResult(new Response<JobApply> { Status = "Error", Message = "Please check details and try again." });

                return new JsonResult(new Response<JobApply> { Status = "Success", Message = "Permission flags are updated successfully!", Data = documents });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
