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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }


        // GET: api/Subscription/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var subscriptions = await _subscriptionService.Get();

                return new JsonResult(new Response<IEnumerable<Subscription>> { Status = "Success", Data = subscriptions });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Subscription/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var subscription = await _subscriptionService.GetById(id);
            if (subscription == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid subscription id" });
            }

            return new JsonResult(new Response<Subscription> { Status = "Success", Data = subscription });
        }


        // DELETE: api/Subscription/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var subscription = await _subscriptionService.GetById(id);
            if (subscription == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid subscription id" });
            }
            await _subscriptionService.Delete(subscription);

            return new JsonResult(new Response<string> { Status = "Success", Message = "Subscription deleted successfully!" });
        }


        // PUT: api/Subscription/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Subscription subscription)
        {
            try
            {
                if (subscription == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Subscription is null" });
                }
                await _subscriptionService.Update(subscription);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Subscription updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }



        // POST: api/Subscription/Add
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Subscription subscription)
        {
            try
            {
                if (subscription == null)
                    return BadRequest("Subscription is null");

                var subscriptionData = await _subscriptionService.Add(subscription);

                if (subscriptionData == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Subscription Creation failed! Please check details and try again." });

                return new JsonResult(new Response<Subscription> { Status = "Success", Message = "Subscription created successfully!", Data = subscriptionData });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

    }
}
