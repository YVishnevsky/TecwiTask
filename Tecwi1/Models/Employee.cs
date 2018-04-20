using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tecwi1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
    }
}