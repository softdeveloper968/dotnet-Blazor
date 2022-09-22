using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GaHealthcareNurses.WebService.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListTemplateController : ControllerBase
    {
        private readonly ITaskListTemplateService _taskListTemplateService;
        private readonly IMapper _mapper;
        public TaskListTemplateController(ITaskListTemplateService taskListTemplateService, IMapper mapper)
        {
            _taskListTemplateService = taskListTemplateService;
            _mapper = mapper;
        }

        // GET: api/TaskListTemplate/GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<object> GetAll(string id)
        {
            int count = await _taskListTemplateService.TotalCount(string.Empty,id);
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
                count = await _taskListTemplateService.TotalCount(filterValue,id);
            }
            int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : count;
            var taskListTemplates = await _taskListTemplateService.Get(skip, top, filterValue,id);

            if (taskListTemplates == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });
            }

            return new { Items = taskListTemplates, Count = count };

        }


        [HttpGet]
        [Route("Get")]
        public async Task<object> Get(string id)
        {
            try
            {
                var taskListTemplates = await _taskListTemplateService.GetAll(id);

                return new { Items = taskListTemplates,Count=taskListTemplates.ToList().Count };
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/TaskListTemplate/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var taskListTemplate = await _taskListTemplateService.GetById(id);
            if (taskListTemplate == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid task list template id" });
            }

            return new JsonResult(new Response<TaskListTemplate> { Status = "Success", Data = taskListTemplate });
        }


        // DELETE: api/TaskListTemplate/Delete
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var taskListTemplate = await _taskListTemplateService.GetById(id);
            if (taskListTemplate == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid task list template id" });
            }
            await _taskListTemplateService.Delete(taskListTemplate);

            return new JsonResult(new Response<string> { Status = "Success", Message = "Template deleted successfully!" });
        }


        // PUT: api/TaskListTemplate/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] TaskListTemplate taskListTemplate)
        {
            try
            {
                if (taskListTemplate == null)
                {
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Task list template is null" });
                }
                await _taskListTemplateService.Update(taskListTemplate);

                return new JsonResult(new Response<string> { Status = "Success", Message = "Task list template updated successfully!" });

            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }

        }

        // POST: api/TaskListTemplate/Add
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskListTemplate taskListTemplate)
        {
            try
            {
                if (taskListTemplate == null)
                    return BadRequest("Template is null");

            //   var taskListTemplate= _mapper.Map<TaskListTemplate>(taskListTemplateViewModel);
                var template = await _taskListTemplateService.Add(taskListTemplate);

                if (template == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Template Creation failed! Please check details and try again." });

                return new JsonResult(new Response<TaskListTemplate> { Status = "Success", Message = "Template created successfully!", Data = template });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

    }
}
