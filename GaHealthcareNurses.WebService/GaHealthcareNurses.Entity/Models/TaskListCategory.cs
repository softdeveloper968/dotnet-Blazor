using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaHealthcareNurses.Entity.Models
{
    public  class TaskListCategory
    {
       public int TaskListCategoryId { get; set; }
        public string Category { get; set; }

    }
}

