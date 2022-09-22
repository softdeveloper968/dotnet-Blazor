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
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceService _referenceService;
        public ReferenceController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }


        // GET: api/Reference/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var references = await _referenceService.Get();

                return new JsonResult(new Response<IEnumerable<Reference>> { Status = "Success", Data = references });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Reference/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var reference = await _referenceService.GetById(id);
            if (reference == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid reference id" });
            }

            return new JsonResult(new Response<Reference> { Status = "Success", Data = reference });
        }


        // DELETE: api/Reference/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var reference = await _referenceService.GetById(id);
            if (reference == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid reference id" });
            }
            await _referenceService.Delete(reference);

            return new JsonResult(new Response<string> { Status = "Success", Message = "Reference deleted successfully!" });
        }


        // PUT: api/Reference/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Reference reference)
        {
            try
            {
                if (reference == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Reference is null" });
                }
                await _referenceService.Update(reference);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Reference updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }
    }
}
