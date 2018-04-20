using System;
using System.ComponentModel.DataAnnotations;

namespace Tecwi1.Requests
{
    public class EmployeeDto 
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
