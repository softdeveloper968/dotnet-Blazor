using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Linq;
using GaHealthcareNurses.WebService.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using AutoMapper;
using GaHealthcareNurses.Entity.ViewModels;

namespace GaHealthcareNurses.WebService.Controllers
{
    // [Authorize(Roles = "Employer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly GaHealthcareNursesContext _gaHealthcareNursesContext;
        private readonly ILogger<EmployerController> _logger;
        private IMapper _mapper;
        public EmployerController(IEmployerService employerService, ILogger<EmployerController> logger, GaHealthcareNursesContext gaHealthcareNursesContext)
        {
            _employerService = employerService;
            _logger = logger;
            _gaHealthcareNursesContext = gaHealthcareNursesContext;
        }


        // GET: api/Employer
        [HttpGet]
        public async Task<object> GetAll()
        {
            int count = await _employerService.TotalCount(string.Empty);
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
                count = await _employerService.TotalCount(filterValue);
            }
            int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : count;


            var employers = await _employerService.Get(skip, top, filterValue);
            if (employers == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
            }
            return new { Items = employers, Count = count };

        }

        // GET: api/Employer/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var employers = await _employerService.GetAll();
            if (employers == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
            }
            return new JsonResult(new Response<IEnumerable<Employer>> { Status = "Success", Data = employers });
        }


        // GET: api/Employer/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var employer = await _employerService.GetById(id);
            if (employer == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid employer id" });

            return new JsonResult(new Response<Employer> { Status = "Success", Data = employer });
        }


        // POST: api/Employer
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employer employer)
        {
            if (employer == null)
            {
                return BadRequest("Employer is null");
            }
            await _employerService.Add(employer);
            return CreatedAtRoute(
                "Get", new
                {
                    Id = employer.Id
                }, employer);
        }


        // DELETE: api/Employer/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Employer employer = await _employerService.GetById(id);
            if (employer == null)
            {
                return NotFound("The Employer record couldn't be found.");
            }
            await _employerService.Delete(employer);
            return NoContent();
        }


        // PUT: api/Employer/Update
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update([FromForm] EmployerViewModel employer)
        {
            try
            {
                if (employer == null)
                {
                    return BadRequest("Employer is null.");
                }

                var employerUpdatedData = await _employerService.Update(employer);
                if (employerUpdatedData != null)
                    return new JsonResult(new Response<Employer> { Status = "Success", Data = employerUpdatedData });

                return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message});
            }

        }
    }
}
