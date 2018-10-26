using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using capstoneapi.Data;
using capstoneapi.Models;

namespace capstoneapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExpenseTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ExpenseTypes
        [HttpGet]
        public IEnumerable<ExpenseType> GetExpenseTypes()
        {
            return _context.ExpenseTypes;
        }

        // GET: api/ExpenseTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenseType = await _context.ExpenseTypes.FindAsync(id);

            if (expenseType == null)
            {
                return NotFound();
            }

            return Ok(expenseType);
        }

        // PUT: api/ExpenseTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseType([FromRoute] int id, [FromBody] ExpenseType expenseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expenseType.Id)
            {
                return BadRequest();
            }

            _context.Entry(expenseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseTypeExists(id))
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

        // POST: api/ExpenseTypes
        [HttpPost]
        public async Task<IActionResult> PostExpenseType([FromBody] ExpenseType expenseType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExpenseTypes.Add(expenseType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpenseType", new { id = expenseType.Id }, expenseType);
        }

        // DELETE: api/ExpenseTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expenseType = await _context.ExpenseTypes.FindAsync(id);
            if (expenseType == null)
            {
                return NotFound();
            }

            _context.ExpenseTypes.Remove(expenseType);
            await _context.SaveChangesAsync();

            return Ok(expenseType);
        }

        private bool ExpenseTypeExists(int id)
        {
            return _context.ExpenseTypes.Any(e => e.Id == id);
        }
    }
}