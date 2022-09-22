using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    //   [Authorize(Roles = "Nurse")]
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly INurseService _nurseService;
        private readonly IMapper _mapper;
        public NursesController(INurseService nurseService, IMapper mapper)
        {
            _nurseService = nurseService;
            _mapper = mapper;
        }

        // GET: api/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var nurses = await _nurseService.GetAll();
            //var postsResponse = _mapper.Map<List<items>>(1.Item1);
            return Ok(nurses);
        }

        // GET: api/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            Nurse nurse = await _nurseService.GetById(id);
            if (nurse == null)
            {
                return NotFound("The Nurse record couldn't be found.");
            }
            return Ok(nurse);
        }

        [HttpPost]
        [Route("ChangeUserJobAvailability")]
        public async Task<IActionResult> ChangeUserJobAvailability(JobAvailabilityViewModel jobAvailability)
        {
            var nurseData = await _nurseService.ChangeUserJobAvailability(jobAvailability);
            if (nurseData == null)
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid user id" });

            return new JsonResult(new Response<Nurse> { Status = "Success", Data = nurseData });
        }

        [HttpGet]
        [Route("GetAllNurses")]
        public async Task<object> GetNursesByDecendingDate()
        {
            int allNursesCount = await _nurseService.GetNursesCount(string.Empty);
            var queryString = Request.Query;
            StringValues Skip;
            StringValues Take;
            StringValues Filter;
            int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;

            string filterValue = (queryString.TryGetValue("$filter", out Filter)) ? Convert.ToString(Filter[0])?.Split('\'')[1] : null;
            if (filterValue != null)
            {
                allNursesCount = await _nurseService.GetNursesCount(filterValue);
            }
            int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : allNursesCount;

            var nurses = await _nurseService.GetbyCreatedDate(skip, top, filterValue);

            return Ok(new { Items = nurses, Count = allNursesCount });
        }

        [HttpGet]
        [Route("GetNursesWithState")]
        public async Task<IActionResult> GetNursesWithState()
        {
            var nurses = await _nurseService.GetNurses();
            return Ok(nurses);
        }
        
        [HttpPost]
        [Route("SendReferralEmail")]
        public async Task<IActionResult> SendReferralEmail(SendReferralViewModel sendReferralViewModel)
        {
            try
            {
                if (sendReferralViewModel == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Nurse referral is null" });
                }
                var nurseReferral = await _nurseService.AddReferral(sendReferralViewModel);
                return new JsonResult(new Response<string> { Status = "Success", Message = nurseReferral });
                //return new JsonResult(new Response<string> { Status = "Error", Message = "Nurse is already registered or referral already sent" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("ClaimReward")]
        public async Task<IActionResult> ClaimReward(string nurseId)
        {
            try
            {
               var nurse = await _nurseService.ClaimReward(nurseId);
                return new JsonResult(new Response<string> { Status = "Success", Message = nurse });
              
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("BuyCourses")]
        public async Task<IActionResult> BuyCourses(string nurseId)
        {
            try
            {
               var redirectingUrl = await _nurseService.BuyCourses(nurseId);
                if(redirectingUrl != null)
                {
                    return new JsonResult(new Response<string> { Status = "Success", Data = redirectingUrl });
                }
                return new JsonResult(new Response<string> { Status = "Error", Message = "Nurse is null"});
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("ExecutePayment")]
        public async Task<IActionResult> ExecutePayment(string paymentId, string payerId)
        {
            try
            {
               var isPaymentExecuted = await _nurseService.ExecutePayment(paymentId, payerId);
                if(isPaymentExecuted)
                 return new JsonResult(new Response<string> { Status = "Success", Message = "Payment executed successfully." });

                return new JsonResult(new Response<string> { Status = "Error", Message = "Payment execution failed." });
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
