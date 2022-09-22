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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/Order/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var orders = await _orderService.Get();

                return new JsonResult(new Response<IEnumerable<Order>> { Status = "Success", Data = orders });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/Order/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var order = await _orderService.GetById(id);
            if (order == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid order id" });
            }

            return new JsonResult(new Response<Order> { Status = "Success", Data = order });
        }

        // GET: api/Order/GetByEmployerId
        [HttpGet]
        [Route("GetByEmployerId")]
        public async Task<IActionResult> GetByEmployerId(string id)
        {
            var orders = await _orderService.GetByEmployerId(id);
            if (orders == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid employer id" });
            }

            return new JsonResult(new Response<IEnumerable<Order>> { Status = "Success", Data = orders });
        }



        [HttpPost]
        [Route("AddSubscription")]
        public async Task<IActionResult> AddSubscription(AddSubscriptionViewModel addSubscriptionViewModel)
        {
            try
            {
                if (addSubscriptionViewModel == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Subscription is null" });
                }
                var order = await _orderService.AddSubscription(addSubscriptionViewModel);
                if (order == null)
                {
                    return new JsonResult(new Response<string> { Status = "Success", Message = "Please check details and try again." });
                }

                return new JsonResult(new Response<string> { Status = "Success", Message = "Subscription added successfully!" });
            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        [HttpPost]
        [Route("UpdateSubscription")]
        public async Task<IActionResult> UpdateSubscription(UpdateSubscriptionViewModel updateSubscriptionViewModel)
        {
            try
            {
                await _orderService.UpdateSubscription(updateSubscriptionViewModel);
                return new JsonResult(new Response<string> { Status = "Success", Message = "Subscription updated successfully!" });

            }
            catch(Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        //// DELETE: api/Order/Delete
        //[HttpDelete]
        //[Route("Delete")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var order = await _orderService.GetById(id);
        //    if (order == null)
        //    {
        //        return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid order id" });
        //    }
        //    await _orderService.Delete(order);

        //    return new JsonResult(new Response<string> { Status = "Success", Message = "Order deleted successfully!" });
        //}


        // PUT: api/Order/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Order is null" });
                }
                await _orderService.Update(order);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Order updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }



        //// POST: api/Order/Add
        //[Route("Add")]
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Order order)
        //{
        //    try
        //    {
        //        if (order == null)
        //            return BadRequest("Order is null");

        //        var orderData = await _orderService.Add(order);

        //        if (orderData == null)
        //            return new JsonResult(new Response<string> { Status = "Error", Message = "Order Creation failed! Please check details and try again." });

        //        return new JsonResult(new Response<Order> { Status = "Success", Message = "Order created successfully!", Data = orderData });
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
        //    }
        //}

        /// <summary>
        /// Get active subscription order by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetActiveOrder")]
        public async Task<IActionResult> GetActiveOrder(string id)
        {
            var orders = await _orderService.GetActiveOrder(id);
            if (orders == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid employer id" });
            }

            return new JsonResult(new Response<IEnumerable<Order>> { Status = "Success", Data = orders });
        }

    }
}
