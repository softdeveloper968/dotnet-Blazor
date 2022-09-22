using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public partial class TaskListCalender
    {
        public string Date { get; set; }
        public bool Completed { get; set; }

    }
}

