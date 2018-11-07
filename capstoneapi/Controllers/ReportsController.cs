using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using capstoneapi.Data;
using capstoneapi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace capstoneapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CapstonePolicy")]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Reports
        [HttpGet]
        [Authorize]
        public IEnumerable<Report> GetReports()
        {
            var user = _context.Employees.SingleOrDefault(u => u.UserName == User.Identity.Name);

            return _context.Reports
                .Include(r => r.Employee)
                .Include(r => r.Expenses)
                .ThenInclude(expense => expense.ExpenseTypes)
                .Where(r => r.Employee.Id == user.Id);


            //var dbReports = _context.Reports
            //    .Include(r => r.Expenses);

            //var json = JsonConvert.SerializeObject(new { reports = dbReports });
            //return json;
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetReport([FromRoute] int id)
        {
            var user = _context.Employees.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var expenses = await _context.Expenses
                            .Where(e => e.ReportId == id)
                            .Include(expense => expense.ExpenseTypes)
                            .Include(e => e.Photos)
                            .OrderByDescending(e => e.ExpenseDate)
                            .ToListAsync();

            var report = await _context.Reports
                            .Include(r => r.Employee)
                            .Where(r => r.Id == id)
                            .Where(r => r.Employee == user)
                            .SingleAsync();

            report.Expenses = expenses;

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        //PUT: api/Reports/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutReport([FromRoute] int id, [FromBody] Report report)
        {
            var user = _context.Employees.SingleOrDefault(u => u.UserName == User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != report.Id)
            {
                return BadRequest();
            }

            report.EmployeeId = user.Id;
            _context.Entry(report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reports
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostReport([FromBody] Report report)
        {
            var user = _context.Employees.SingleOrDefault(u => u.UserName == User.Identity.Name);

            Console.WriteLine("test");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            report.EmployeeId = user.Id;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReport", new { id = report.Id }, report);
        }

        // DELETE: api/Reports/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteReport([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var report = await _context.Reports.FindAsync(id);
        //        if (report == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Reports.Remove(report);
        //        await _context.SaveChangesAsync();

        //        return Ok(report);
        //    }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }
    }
}