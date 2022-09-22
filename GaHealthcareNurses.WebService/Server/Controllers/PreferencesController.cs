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
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferencesService _preferencesService;
        public PreferencesController(IPreferencesService preferencesService)
        {
            _preferencesService = preferencesService;
        }


        // GET: api/Preferences/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var nurse = await _preferencesService.GetById(id);
            if (nurse == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid user id" });

            return new JsonResult(new Response<Nurse> { Status = "Success", Data = nurse });
        }



        // POST: api/Preferences/Add
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PreferencesViewModel preferences)
        {
            try
            {
                if (preferences == null)
                    return BadRequest("Preferences is null");

                var preferencesData = await _preferencesService.AddPreferences(preferences);

                if (preferencesData == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Preferences Creation failed! Please check details and try again." });

                return new JsonResult(new Response<Nurse> { Status = "Success", Message = "Preferences created successfully!", Data = preferencesData });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
