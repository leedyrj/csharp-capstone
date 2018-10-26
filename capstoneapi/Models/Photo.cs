using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace capstoneapi.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string PhotoName { get; set; }

        public string PhotoPath { get; set; }

        [Required]
        public Expense Expense { get; set; }
    }
}
