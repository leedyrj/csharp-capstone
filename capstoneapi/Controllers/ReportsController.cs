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
        public IEnumerable<Report> GetReports()
        {
            return _context.Reports
                .Include(r => r.Expenses)
                .ThenInclude(expense => expense.ExpenseTypes)
                .Include(r => r.Employee);


            //var dbReports = _context.Reports
            //    .Include(r => r.Expenses);

            //var json = JsonConvert.SerializeObject(new { reports = dbReports });
            //return json;
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var report = await _context.Reports
                            .Include(r => r.Expenses)
                            .ThenInclude(expense => expense.ExpenseTypes)
                            .Include(r => r.Employee)
                            .Where(r => r.Id == id)
                            .SingleAsync();

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        // PUT: api/Reports/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutReport([FromRoute] int id, [FromBody] Report report)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != report.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(report).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ReportExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Reports
        [HttpPost]
        public async Task<IActionResult> PostReport([FromBody] Report report)
        {
            Console.WriteLine("test");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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

    //    private bool ReportExists(int id)
    //    {
    //        return _context.Reports.Any(e => e.Id == id);
    //    }
    }
}