using Contracts.ServiceContracts;
using GaHealthcareNurses.Entity.Models;
using GaHealthcareNurses.Entity.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.WebService.Controllers
{
    [Route("api/")]
    [ApiController]
    public class JobInvitationController : ControllerBase
    {
        private readonly IJobInvitationService _jobInvitationService;
        public JobInvitationController(IJobInvitationService jobInvitationService)
        {
            _jobInvitationService = jobInvitationService;
        }

        // POST: api/SendJobInvitation
        [Route("SendJobInvitation")]
        [HttpPost]
        public async Task<IActionResult> SendInvitation(JobInvitationViewModel jobInvitationViewModel)
        {
            try
            {
                if (jobInvitationViewModel.Jobs == null || jobInvitationViewModel.Employers == null)
                    return new JsonResult(new Response<string> { Status = "Error", Message = "Please check details and try again." });

               var jobInvitations= await _jobInvitationService.SendJobInvitation(jobInvitationViewModel.Jobs, jobInvitationViewModel.Employers);

                if(jobInvitations == jobInvitationViewModel.Jobs.Count * jobInvitationViewModel.Employers.Count)
                return new JsonResult(new Response<string> { Status = "Success", Message = "Job Invitation is sent to all agencies." });

                return new JsonResult(new Response<string> { Status = "Error", Message = "Job invitation is not sent to all agencies,please try again." });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }

    }
}
