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
    public class TaskListCategoryController : ControllerBase
    {
        private readonly ITaskListCategoryService _taskListCategoryService;
        public TaskListCategoryController(ITaskListCategoryService taskListCategoryService)
        {
            _taskListCategoryService = taskListCategoryService;
        }


        // GET: api/TaskListCategory/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var taskListCategories = await _taskListCategoryService.Get();

                return new JsonResult(new Response<IEnumerable<TaskListCategory>> { Status = "Success", Data = taskListCategories });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskListCategory/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskListCategory = await _taskListCategoryService.GetById(id);
            if (taskListCategory == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid task list category id" });
            }

            return new JsonResult(new Response<TaskListCategory> { Status = "Success", Data = taskListCategory });
        }


        // DELETE: api/TaskListCategory/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskListCategory = await _taskListCategoryService.GetById(id);
            if (taskListCategory == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid task list category id" });
            }
            await _taskListCategoryService.Delete(taskListCategory);

            return new JsonResult(new Response<string> { Status = "Success", Message = "category deleted successfully!" });
        }


        // PUT: api/TaskListCategory/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] TaskListCategory taskListCategory)
        {
            try
            {
                if (taskListCategory == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Task list category is null" });
                }
                await _taskListCategoryService.Update(taskListCategory);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Task list category updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }



        // POST: api/TaskListCategory/Add
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskListCategory taskListCategory)
        {
            try
            {
                if (taskListCategory == null)
                    return BadRequest("Status is null");

                var category = await _taskListCategoryService.Add(taskListCategory);

                if (category == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Category Creation failed! Please check details and try again." });

                return new JsonResult(new Response<TaskListCategory> { Status = "Success", Message = "Category created successfully!", Data = category });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

    }
}
