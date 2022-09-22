using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
   // [Authorize(Roles = "Client")]
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceListController : ControllerBase
    {
        private readonly IServiceListService _serviceListService;
        public ServiceListController(IServiceListService serviceListService)
        {
            _serviceListService = serviceListService;
        }


        // GET: api/ServiceList
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var services = await _serviceListService.Get();

                return new JsonResult(new Response<IEnumerable<ServiceList>> { Status = "Success", Data = services });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var service = await _serviceListService.GetById(id);
            if (service == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid service id" });
            }

            return new JsonResult(new Response<ServiceList> { Status = "Success", Data = service });
        }
    }
}
