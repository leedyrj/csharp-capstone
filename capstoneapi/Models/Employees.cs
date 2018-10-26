using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneapi.Models
{
    public class Employees
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public Departments Departments { get; set; }
    }
}
