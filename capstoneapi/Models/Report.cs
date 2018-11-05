using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capstoneapi.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Display(Name = "Date Submitted")]
        public DateTime SubmittedDate { get; set; }

        public bool Submitted { get; set; }

        [Required]
        //[Display(Name = "Destination/Purpose")]
        public string Purpose { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
