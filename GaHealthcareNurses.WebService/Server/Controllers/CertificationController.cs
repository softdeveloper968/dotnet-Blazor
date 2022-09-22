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
    public class CertificationController : ControllerBase
    {
        private readonly ICertificationService _certificationService;
        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }


        // GET: api/Certification/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var certifications = await _certificationService.Get();

                return new JsonResult(new Response<IEnumerable<Certification>> { Status = "Success", Data = certifications });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Certification/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var certification = await _certificationService.GetById(id);
            if (certification == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid certification id" });
            }

            return new JsonResult(new Response<Certification> { Status = "Success", Data = certification });
        }


        // DELETE: api/Certification/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var certification = await _certificationService.GetById(id);
            if (certification == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid certification id" });
            }
            await _certificationService.Delete(certification);

            return new JsonResult(new Response<string> { Status = "Success", Message = "Certification deleted successfully!" });
        }


        // PUT: api/Certification/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Certification certification)
        {
            try
            {
                if (certification == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Certification is null" });
                }
                await _certificationService.Update(certification);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Certification updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }
    }
}
