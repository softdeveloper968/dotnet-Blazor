using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaHealthcareNurses.Entity.ViewModels
{
    public class AddSignatureViewModel
    {
        public string NurseId { get; set; }
        public int JobId { get; set; }
        public string Date { get; set; }
        public IFormFile Signature { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime? TaskVerifiedTime { get; set; }

    }
}
