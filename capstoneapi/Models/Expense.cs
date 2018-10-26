using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capstoneapi.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Description of Expense")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Expense Date")]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [Display(Name = "Location of Expense")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Type of Expense")]
        public int ExpenseTypeId { get; set; }
        public ExpenseType ExpenseTypes { get; set; } 

        [Required]
        public int ReportId { get; set; }
        public Report Report { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
