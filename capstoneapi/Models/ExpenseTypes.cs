using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneapi.Models
{
    public class ExpenseTypes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public string ExpenseTypeName { get; set; }
    }
}
