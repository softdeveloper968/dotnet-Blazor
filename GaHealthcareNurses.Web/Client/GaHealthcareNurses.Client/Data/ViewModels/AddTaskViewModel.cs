using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GaHealthcareNurses.Client.Data.ViewModels
{
    public class AddTaskViewModel
    {
        [Required]
        public string TaskName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Select a Category")]
        public int TaskCategoryId { get; set; }

    }
}
