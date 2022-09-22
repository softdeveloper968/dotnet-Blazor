using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
  //  [Authorize(Roles = "Nurse")]
    [Route("api/[controller]")]
    [ApiController]
    public class HiringAggrementsController : ControllerBase
    {
        private readonly IHiringAggrementsService _hiringAggrementsService;
        private readonly IMapper _mapper;
        public HiringAggrementsController(IHiringAggrementsService hiringAggrementsService, IMapper mapper)
        {
            _hiringAggrementsService = hiringAggrementsService;
            _mapper = mapper;
        }



        // GET: api/HiringAggrements/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var hiringAgreements = await _hiringAggrementsService.Get();

                return new JsonResult(new Response<IEnumerable<HiringAgreements>> { Status = "Success", Data = hiringAgreements });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/HiringAggrements/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var hiringAgreements = await _hiringAggrementsService.GetById(id);
            if (hiringAgreements == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid hiringAgreement id" });
            }

            return new JsonResult(new Response<HiringAgreements> { Status = "Success", Data = hiringAgreements });
        }



        // POST: api/HiringAggrements/Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(HiringAggrementsViewModel hiringAgreements)
        {
            try
            {
                if (hiringAgreements == null)
                {
                    return BadRequest("Hiring aggrement is null");
                }
               var aggrements= _mapper.Map<HiringAgreements>(hiringAgreements);
                await _hiringAggrementsService.AddHiringAggrement(aggrements);

                return new JsonResult(new Response<HiringAgreements> { Status = "Success", Message = "Hiring aggrements created successfully!",Data=aggrements });
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message=ex.Message });
            }
        }

        //// POST: api/HiringAggrements/AddDeclinationOfInfluenzaVaccination
        //[HttpPost]
        //[Route("AddDeclinationOfInfluenzaVaccination")]
        //public async Task<IActionResult> AddDeclinationOfInfluenzaVaccination(DeclinationOfInfluenzaVaccination declinationOfInfluenzaVaccination)
        //{
        //    try
        //    {
        //        if (declinationOfInfluenzaVaccination == null)
        //        {
        //            return BadRequest("Hiring aggrement is null");
        //        }
        //        await _hiringAggrementsService.AddHiringAggrement(aggrements);

        //        return new JsonResult(new Response<HiringAgreements> { Status = "Success", Message = "Hiring aggrements created successfully!", Data = aggrements });
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
        //    }
        //}




        // PUT: api/HiringAggrements/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] HiringAggrementsViewModel hiringAgreements)
        {
            try
            {
                var aggrements = _mapper.Map<HiringAgreements>(hiringAgreements);
                await _hiringAggrementsService.UpdateHiringAggrement(aggrements);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Data updated successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
