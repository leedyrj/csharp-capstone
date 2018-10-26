using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneapi.Models
{
    public class Photos
    {
        public int Id { get; set; }

        public string PhotoName { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public int ExpenseId { get; set; }
        public Expenses Expenses { get; set; }
    }
}
