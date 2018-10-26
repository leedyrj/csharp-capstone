using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace capstoneapi.Models
{
    public class Reports
    {
        public int Id { get; set; }

        [Display(Name = "Date Submitted")]
        public DateTime SubmittedDate { get; set; }

        public bool Submitted { get; set; }

        [Required]
        [Display(Name = "Destination/Purpose")]
        public string Purpose { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employees Employees { get; set; }
    }
}
