using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }


        // GET: api/city
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.Get();

            return new JsonResult(new Response<IEnumerable<City>> { Status = "Success", Data= cities });

        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await _cityService.GetById(id);
            if (city == null)
            {
                return new JsonResult(new Response<string> { Status = "Error",Message="Invalid city id" });
            }

            return new JsonResult(new Response<City> { Status = "Success", Data = city });
        }

        [HttpGet]
        [Route("GetByStateId")]
        public async Task<IActionResult> GetByStateId(int stateId)
        {
            var cities = await _cityService.GetByStateId(stateId);
            if (cities == null)
            {
                return new JsonResult(new Response<IEnumerable<City>> { Status = "Success",Data=cities });
            }

            return new JsonResult(new Response<IEnumerable<City>> { Status = "Success", Data = cities });

        }
    }
}
