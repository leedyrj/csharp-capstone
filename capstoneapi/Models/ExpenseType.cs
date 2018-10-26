using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capstoneapi.Models
{
    public class ExpenseType
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Expense Type")]
        public string ExpenseTypeName { get; set; }
    }
}
