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
    public class UploadDocumentsController : ControllerBase
    {
        private readonly IUploadDocumentsService _uploadDocumentsService;
        private readonly IMapper _mapper;
        public UploadDocumentsController(IUploadDocumentsService uploadDocumentsService, IMapper mapper)
        {
            _uploadDocumentsService = uploadDocumentsService;
            _mapper = mapper;
        }


        // GET: api/UploadDocuments/GetAll
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var uploadDocuments = await _uploadDocumentsService.Get();

                return new JsonResult(new Response<IEnumerable<UploadDocuments>> { Status = "Success", Data = uploadDocuments });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // GET: api/UploadDocuments/GetById
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var uploadDocuments = await _uploadDocumentsService.GetById(id);
            if (uploadDocuments == null)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = "Invalid uploadDocuments id" });
            }

            return new JsonResult(new Response<UploadDocuments> { Status = "Success", Data = uploadDocuments });
        }


        // POST: api/UploadDocuments/Add
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post([FromForm] UploadDocumentsViewModel uploadDocuments)
        {
            try
            {
             var documents= await _uploadDocumentsService.UploadDocuments(uploadDocuments);
                return new JsonResult(new Response<UploadDocuments> { Status = "Success",Message="Documents added successfully!", Data = documents });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }


        // PUT: api/UploadDocuments/Update
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromForm] UploadDocumentsViewModel uploadDocuments)
        {
            try
            {
                var documents = await _uploadDocumentsService.UpdateDocuments(uploadDocuments);

                return new JsonResult(new Response<UploadDocuments> { Status = "Success",Message="Documents updated successfully!", Data = documents });
            }
            catch (Exception ex)
            {
                return new JsonResult(new Response<string> { Status = "Error", Message = ex.Message });
            }
        }
    }
}
