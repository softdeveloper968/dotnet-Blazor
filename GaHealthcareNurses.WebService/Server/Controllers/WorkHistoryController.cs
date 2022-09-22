using AutoMapper;
using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class WorkHistoryController : ControllerBase
    {
        private readonly IWorkHistoryService _workHistoryService;
        private readonly IMapper _mapper;
        public WorkHistoryController(IWorkHistoryService workHistoryService, IMapper mapper)
        {
            _workHistoryService = workHistoryService;
            _mapper = mapper;
        }


        // GET: api/GetWorkHistoryForJob
        [HttpPost]
        [Route("GetWorkHistoryForJob")]
        public async Task<IActionResult> GetWorkHistoryForJob(WorkHistoryViewModel workHistoryViewModel)
        {
            try
            {
                var workHistory = await _workHistoryService.GetWorkHistory(workHistoryViewModel);
                if (workHistory != null || workHistory.Count != 0)
                    return new JsonResult(new Response<List<WorkHistoryResponseModel>> { Status = "Success", Data = workHistory });

                return new JsonResult(new Response<string> { Status = "Success", Message = "Please enter valid details and try again." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

        // GET: api/GetWorkHistoryForNurse
        [HttpGet]
        [Route("GetWorkHistoryForNurse")]
        public async Task<IActionResult> GetWorkHistoryForNurse(string id)
        {
            try
            {
                var workHistory = await _workHistoryService.GetWorkHistoryForNurse(id);
                if (workHistory != null)
                    return new JsonResult(new Response<IEnumerable<NurseWorkHistoryViewModel>> { Status = "Success", Data = workHistory });

                return new JsonResult(new Response<string> { Status = "Success", Message = "Please enter valid details and try again." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
