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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        private readonly IMapper _mapper;
        public StatusController(IStatusService statusService, IMapper mapper)
        {
            _statusService = statusService;
            _mapper = mapper;
        }


        // GET: api/Status/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var statuses = await _statusService.Get();
                return new JsonResult(new Response<IEnumerable<Status>> { Status = "Success", Data = statuses });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Status/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var status = await _statusService.GetById(id);
            if (status == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid status id" });

            return new JsonResult(new Response<Status> { Status = "Success", Data = status });
        }



        // GET: api/Status/GetByTypeId
        [HttpGet]
        [Route("GetByTypeId")]
        public async Task<IActionResult> GetByTypeId(int id)
        {
            var status = await _statusService.GetByTypeId(id);
            if (status == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid status id" });

            return new JsonResult(new Response<IEnumerable<Status>> { Status = "Success", Data = status });
        }

        // POST: api/Status/Add
        [Route("Post")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Status status)
        {
            try
            {
                if (status == null)
                    return BadRequest("Status is null");

                var statusData = await _statusService.Add(status);

                if (statusData == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Status Creation failed! Please check details and try again." });

                return new JsonResult(new Response<Status> { Status = "Success", Message = "Status created successfully!", Data = statusData });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // PUT: api/Status
        [Route("Put")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Status status)
        {
            try
            {
                if (status == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "status is null" });
                }

                await _statusService.Update(status);
                return new JsonResult(new Response<string> { Status = "Success", Message = "Status updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
