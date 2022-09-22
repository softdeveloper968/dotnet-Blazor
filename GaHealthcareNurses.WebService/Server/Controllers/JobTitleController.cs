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
    public class JobTitleController : ControllerBase
    {
        private readonly IJobTitleService _jobTitleService;
        public JobTitleController(IJobTitleService jobTitleService)
        {
            _jobTitleService = jobTitleService;
        }

        // GET: api/JobTitle/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var jobTitles = await _jobTitleService.Get();
                return new JsonResult(new Response<IEnumerable<JobTitle>> { Status = "Success", Data = jobTitles });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/JobTitle/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var jobTitle = await _jobTitleService.GetById(id);
            if (jobTitle == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid job title id" });

            return new JsonResult(new Response<JobTitle> { Status = "Success", Data = jobTitle });
        }

        // POST: api/JobTitle/Add
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JobTitle jobTitle)
        {
            try
            {
                if (jobTitle == null)
                    return BadRequest("Job status is null");

                var title = await _jobTitleService.Add(jobTitle);

                if (title == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Job title Creation failed! Please check details and try again." });

                return new JsonResult(new Response<JobTitle> { Status = "Success", Message = "Job title created successfully!", Data = title });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
