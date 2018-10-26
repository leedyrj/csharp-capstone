using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneapi.Models
{
    public class Expenses
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
        public ExpenseTypes expenseTypes { get; set; } 

        [Required]
        public int ReportId { get; set; }
        public Reports reports { get; set; }
    }
}
