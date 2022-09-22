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
   // [Authorize(Roles = "Nurse")]
    [Route("api/")]
    [ApiController]
    public class UploadPicAndResumeController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;
        public UploadPicAndResumeController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }


        // POST: api/UploadPicAndResume
        [HttpPost]
        [Route("UploadPicAndResume")]
        public async Task<IActionResult> Post([FromForm]UploadFileViewModel fileViewModel)
        {
            var nurse = await _fileUploadService.UploadFiles(fileViewModel);

            return new JsonResult(new Response<Nurse> { Status = "Success", Data= nurse });

        }

        //Delete: api/DeleteProfilePicture
        [HttpDelete]
        [Route("DeleteProfilePicture")]
        public async Task<IActionResult> Delete(string id)
        {
           var isDeleted= await _fileUploadService.DeleteProfilePicture(id);
            if(isDeleted)
            return new JsonResult(new Response<string> { Status = "Success", Message = "Profile picture deleted successfully!" });

            return new JsonResult(new Response<string> { Status = "Error", Message = "Profile picture not exist in blob storage." });
        }
    }
}
