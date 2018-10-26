using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneapi.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        public int Budget { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
