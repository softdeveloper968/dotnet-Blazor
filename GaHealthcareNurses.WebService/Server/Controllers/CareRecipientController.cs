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
  //  [Authorize(Roles = "Client")]
    [Route("api/[controller]")]
    [ApiController]
    public class CareRecipientController : ControllerBase
    {
        private readonly ICareRecipientService _careRecipientService;
        private readonly GaHealthcareNursesContext _gaHealthcareNursesContext;
        private readonly ICityService _cityService;
        private readonly ILogger<JobController> _logger;
        private readonly IMapper _mapper;
        public CareRecipientController(ICareRecipientService careRecipientService, ILogger<JobController> logger, GaHealthcareNursesContext gaHealthcareNursesContext, IMapper mapper, ICityService cityService)
        {
            _careRecipientService = careRecipientService;
            _logger = logger;
            _gaHealthcareNursesContext = gaHealthcareNursesContext;
            _mapper = mapper;
            _cityService = cityService;
        }



        //  GET: api/CareRecipient/GetAll
        [HttpGet]
       [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var careRecipients = await _careRecipientService.Get();

                return new JsonResult(new Response<IEnumerable<CareRecipient>> { Status = "Success", Data = careRecipients });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        //  GET: api/CareRecipient/GetById
        [HttpGet]
       [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var careRecipient = await _careRecipientService.GetById(id);
            if (careRecipient == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid care recipient id" });
            }

            return new JsonResult(new Response<CareRecipient> { Status = "Success", Data = careRecipient });
        }


        //  POST: api/CareRecipient/Add
        [Route("Post")]
       [HttpPost]
        public async Task<IActionResult> Post([FromBody] CareRecipientViewModel careRecipientViewModel)
        {
            try
            {
                if (careRecipientViewModel == null)
                {
                    return BadRequest("CareRecipient is null");
                }

                var careRecipient = _mapper.Map<CareRecipient>(careRecipientViewModel);
                 await _careRecipientService.Add(careRecipient);
               
                   return new JsonResult(new Response<CareRecipient> { Status = "Success", Message = "Care recipient created successfully!", Data = careRecipient });
                
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // DELETE: api/CareRecipient/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var careRecipient = await _careRecipientService.GetById(id);
                if (careRecipient == null)
                {
                    return NotFound("The Job record couldn't be found.");
                }
                await _careRecipientService.Delete(careRecipient); 
                return new JsonResult(new Response<string> { Status = "Success", Message = "Care recipient deleted successfully!"});
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message});
            }
        }


        // PUT: api/CareRecipient/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] CareRecipientViewModel careRecipientViewModel)
        {
            try
            {
                if (careRecipientViewModel == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Care recipient is null" });
                }
                var careRecipient = _mapper.Map<CareRecipient>(careRecipientViewModel);
                await _careRecipientService.Update(careRecipient);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Care recipient updated successfully!" });

            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
          
        }
    }
}
