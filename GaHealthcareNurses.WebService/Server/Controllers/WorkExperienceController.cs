using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        private readonly IWorkExperienceService _workExperienceService;
        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }


        // GET: api/WorkExperience/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var workExperiences = await _workExperienceService.Get();

                return new JsonResult(new Response<IEnumerable<WorkExperience>> { Status = "Success", Data = workExperiences });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/WorkExperience/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var workExperience = await _workExperienceService.GetById(id);
            if (workExperience == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid work experience id" });
            }

            return new JsonResult(new Response<WorkExperience> { Status = "Success", Data = workExperience });
        }


        // DELETE: api/WorkExperience/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var workExperience = await _workExperienceService.GetById(id);
            if (workExperience == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid work experience id" });
            }
            await _workExperienceService.Delete(workExperience);

            return new JsonResult(new Response<string> { Status = "Success", Message = "Work experience deleted successfully!" });
        }


        // PUT: api/WorkExperience/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] WorkExperience workExperience)
        {
            try
            {
                if (workExperience == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Work experience is null" });
                }
                await _workExperienceService.Update(workExperience);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Work experience updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }
    }
}
