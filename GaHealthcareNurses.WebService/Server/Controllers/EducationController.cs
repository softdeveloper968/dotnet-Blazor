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
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }


        // GET: api/Education/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var educations = await _educationService.Get();

                return new JsonResult(new Response<IEnumerable<Education>> { Status = "Success", Data = educations });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Education/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var education = await _educationService.GetById(id);
            if (education == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid education id" });
            }

            return new JsonResult(new Response<Education> { Status = "Success", Data = education });
        }


        // DELETE: api/Education/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var education = await _educationService.GetById(id);
            if (education == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid education id" });
            }
            await _educationService.Delete(education);

            return new JsonResult(new Response<string> { Status = "Success", Message = "Education deleted successfully!" });
        }


        // PUT: api/Education/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Education education)
        {
            try
            {
                if (education == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Education is null" });
                }
                await _educationService.Update(education);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Education updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }
    }
}
