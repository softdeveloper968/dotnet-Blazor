using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Services.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;
        private readonly INurseService _nurseService;
        private readonly IPushNotificationService _pushNotificationService;
        private readonly ILogger<JobController> _logger;
        private readonly IMapper _mapper;
        private readonly IJobApplyService _jobApplyService;
        private readonly IJobApplyForAgencyService _jobApplyForAgencyService;
        private readonly IStatusService _statusService;
        //private readonly IUriService _uriService;
        public JobController(IJobService jobService, IPushNotificationService pushNotificationService, INurseService nurseService, ILogger<JobController> logger, IMapper mapper/*,IUriService uriService*/, IJobApplyService jobApplyService, IJobApplyForAgencyService jobApplyForAgencyService,IStatusService statusService)
        {
            _jobService = jobService;
            _pushNotificationService = pushNotificationService;
            _nurseService = nurseService;
            _logger = logger;
            _mapper = mapper;
            _jobApplyService = jobApplyService;
            _jobApplyForAgencyService = jobApplyForAgencyService;
            _statusService = statusService;
        }


        ////POST:api/job/GetAllForAgency
        //[HttpPost]
        //[Route("GetAllForAgency")]
        //public async Task<IActionResult> GetAllForAgency(PaginationFilter paginationFilter)
        //{

        //    var jobs = await _jobService.GetJobsForAgency(paginationFilter);
        //    if (jobs == null)
        //    {
        //        return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
        //    }
        //    return new JsonResult(new Response<GetJobsForAgencyViewModel> { Status = "Success", Data = jobs });

        //}



        //GET:api/job/GetAllForAgency
        [HttpGet]
        [Route("GetAllForAgency")]
        public async Task<object> GetAllForAgency()
        {
            int count = await _jobService.TotalCount(string.Empty);
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
                count = await _jobService.TotalCount(filterValue);
            }
            int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : count;

            var jobs = await _jobService.GetJobsForAgency(skip, top, filterValue);

            var getJobs = _mapper.Map<IEnumerable<GetJobsForAgencyViewModel>>(jobs);

            foreach(var job in getJobs.ToList())
            {
               var jobsApplied= await _jobApplyForAgencyService.GetByJobId(job.JobId);
                foreach(var jobapply in jobsApplied)
                {
                    if (jobapply.StatusId == 13)
                    {
                        job.StatusId = jobapply.StatusId;
                        break;
                    }
                    job.StatusId = 12;
                }
                //if (jobsApplied.ToList().Count > 0)
                //{
                //    job.StatusId = 12;
                //}

            }

            if(getJobs == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
            }
            
            return new { Items = getJobs, Count = count };

        }




        // POST: api/Job/GetAll
        [HttpPost]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(GetAllJobsViewModel getAllJobsViewModel)
        {
            try
            {
                var paginationfilter = getAllJobsViewModel.PaginationFilter;
                var jobs = await _jobService.Get(paginationfilter);
                var getJobs = _mapper.Map<List<GetJobsViewModel>>(jobs);
               foreach(var job in getJobs.ToList())
                {
                 //  var jobsApplied= await _jobApplyService.GetByJobId(job.JobId);
                    foreach(var jobApplied in job.JobApplies.ToList())
                    {
                        if (jobApplied.StatusId == 1 || jobApplied.StatusId == 6 || jobApplied.StatusId == 7 || jobApplied.StatusId == 10)
                        {
                            getJobs.Remove(job);
                            break;
                        }

                        if (getAllJobsViewModel.UserId == jobApplied.NurseId)
                        {
                            job.JobApplyId = jobApplied.Id;
                            job.StatusId = jobApplied.StatusId;
                            job.Status = await _statusService.GetById((int)job.StatusId);
                            job.AppliedRate = jobApplied.PrefferedRate;
                            job.OfferedRate = jobApplied.OfferedRate;
                            job.AcceptJobDescriptionAndPolicies = jobApplied.AcceptJobDescriptionAndPolicies;
                            job.DocumentsCanBeShared = jobApplied.DocumentsCanBeShared;
                            job.SSNCanBeShared = jobApplied.SSNCanBeShared;
                            job.CNACanBeShared = jobApplied.CNACanBeShared;
                            job.CPRCanBeShared = jobApplied.CPRCanBeShared;
                            job.DrivingLicenseCanBeShare = jobApplied.DrivingLicenseCanBeShare;
                            job.TBResultsCanBeShared = jobApplied.TBResultsCanBeShared;
                            job.W4CanBeShared = jobApplied.W4CanBeShared;
                            job.HiringDisclosuresCanBeShared = jobApplied.HiringDisclosuresCanBeShared;
                            job.HiringPreScreeningCanBeShared = jobApplied.HiringPreScreeningCanBeShared;
                            job.G4CanBeShared = jobApplied.G4CanBeShared;
                            //job.ClientFeedback = jobApplied.ClientFeedback;
                            //job.NurseFeedback = jobApplied.NurseFeedback;
                            //job.ClientRating = jobApplied.ClientRating;
                            //job.NurseRating = jobApplied.NurseRating;
                        }
                    }
                    
                }
                return new JsonResult(new Response<IEnumerable<GetJobsViewModel>> { Status = "Success", Data = getJobs });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Job/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var job = await _jobService.GetById(id);
            if (job == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id" });

            return new JsonResult(new Response<Job> { Status = "Success", Data = job });
        }


        // GET: api/Job/GetByClientId
        [HttpGet]
        [Route("GetByClientId")]
        public async Task<IActionResult> GetByClientId(string id)
        {
            var jobs = await _jobService.GetByClientId(id);
            if (jobs == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid client id" });

            return new JsonResult(new Response<IEnumerable<Job>> { Status = "Success", Data = jobs });
        }


        // POST: api/Job/Post
        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobViewModel job)
        {
            try
            {
                if (job == null)
                    return BadRequest("Job is null");

                var jobs = _mapper.Map<Job>(job);
                var jobData = await _jobService.Add(jobs);

                if (jobData == null)
                    return new JsonResult(new Response<Job> { Status = "Error", Message = "Job creation failed! Please check job details and try again." });


                //var dataObj = new
                //{
                //    title = jobData.JobTitle.Title,
                //    body = job.Description,
                //    sound = "default",
                //    messageType = "New Job"
                //};

                //var dataWrapper = new { data = dataObj };
                //var nursesData = await _nurseService.GetAll();
                //foreach (var item in nursesData)
                //{
                //    if (!string.IsNullOrEmpty(item.FirebaseToken))
                //    {
                //        if (item.IsUserAvailableForJob)
                //        {
                //            bool status = await _pushNotificationService.SendNotification(new
                //            {
                //                //to = "d9KonoX9IhQ:APA91bE2h7_2ekOI3j6oJQwcesI03U9xoVp8txPx5R0bN7COixxBSEgQUEMurK9IzW_k9zccG561QQr2AgN22PUrvhE6IyfGEkZK3iLbIv4tZz-ZUqsY6Sd8fGb8QlHswYus4VJHmqcU",
                //                priority = "high",
                //                to = item.FirebaseToken,
                //                notification = dataObj
                //            });
                //        }
                //    }
                //}
                return new JsonResult(new Response<Job> { Status = "Success", Message = "Job created successfully!", Data = jobs });
                //if (status)
                //    return new JsonResult(new Response<Job> { Status = "Success", Message = "Job created successfully!", Data = jobs });
                //else
                //    return new JsonResult(new Response<Job> { Status = "Error", Message = "Issue in sending notification", Data = jobs });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        //// DELETE: api/Job/1
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Job job = await _jobService.GetById(id);
        //    if (job == null)
        //    {
        //        return NotFound("The Job record couldn't be found.");
        //    }
        //    await _jobService.Delete(job);
        //    return NoContent();
        //}


        // PUT: api/Job/Update
        [Route("Repost")]
        [HttpPost]
        public async Task<IActionResult> Repost(int jobId)
        {
            try
            {
              var jobData= await _jobService.GetById(jobId);
                if (jobData != null)
                {
                    Job job = new Job
                    {
                        EmployerId = jobData.EmployerId,
                        ClientId = jobData.ClientId,
                        CareRecipientId = jobData.CareRecipientId,
                        JobTitleId = jobData.JobTitleId,
                        Description = jobData.Description,
                        PostedTime = DateTime.UtcNow,
                        HourlyRate = jobData.HourlyRate,
                        ResourceId = jobData.ResourceId,
                        StatusId = jobData.StatusId,
                    };

                    var jobResponse = await _jobService.Add(job);

                    if (jobResponse == null)
                        return new JsonResult(new Response<Job> { Status = "Error", Message = "Job creation failed! Please check job details and try again." });

                    var dataObj = new
                    {
                        title = jobResponse.JobTitle.Title,
                        body = jobResponse.Description,
                        sound = "default",
                        //        messageType = "Job Notification"
                    };

                    var dataWrapper = new { data = dataObj };
                    var nursesData = await _nurseService.GetAll();
                    foreach (var item in nursesData)
                    {
                        if (!string.IsNullOrEmpty(item.FirebaseToken))
                        {
                            if (item.IsUserAvailableForJob)
                            {
                                bool status = await _pushNotificationService.SendNotification(new
                                {
                                    //to = "d9KonoX9IhQ:APA91bE2h7_2ekOI3j6oJQwcesI03U9xoVp8txPx5R0bN7COixxBSEgQUEMurK9IzW_k9zccG561QQr2AgN22PUrvhE6IyfGEkZK3iLbIv4tZz-ZUqsY6Sd8fGb8QlHswYus4VJHmqcU",
                                    priority = "high",
                                    to = item.FirebaseToken,
                                    notification = dataObj
                                });
                            }
                        }
                    }
                    return new JsonResult(new Response<Job> { Status = "Success", Message = "Job reposted successfully!", Data = jobResponse });
                }

                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job id"});

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
