using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealerShip.Models;
using DealerShip.Presistance;

namespace DealerShip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPersonsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SalesPersonsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/SalesPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesPerson>>> GetSalesPersons()
        {
          if (_context.SalesPersons == null)
          {
              return NotFound();
          }
            return await _context.SalesPersons.ToListAsync();
        }

        // GET: api/SalesPersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesPerson>> GetSalesPerson(int id)
        {
          if (_context.SalesPersons == null)
          {
              return NotFound();
          }
            var salesPerson = await _context.SalesPersons.FindAsync(id);

            if (salesPerson == null)
            {
                return NotFound();
            }

            return salesPerson;
        }

        // PUT: api/SalesPersons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesPerson(int id, SalesPerson salesPerson)
        {
            if (id != salesPerson.ID)
            {
                return BadRequest();
            }

            _context.Entry(salesPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesPersonExists(id))
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

        // POST: api/SalesPersons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesPerson>> PostSalesPerson(SalesPerson salesPerson)
        {
          if (_context.SalesPersons == null)
          {
              return Problem("Entity set 'ApplicationDBContext.SalesPersons'  is null.");
          }
            _context.SalesPersons.Add(salesPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesPerson", new { id = salesPerson.ID }, salesPerson);
        }

        // DELETE: api/SalesPersons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesPerson(int id)
        {
            if (_context.SalesPersons == null)
            {
                return NotFound();
            }
            var salesPerson = await _context.SalesPersons.FindAsync(id);
            if (salesPerson == null)
            {
                return NotFound();
            }

            _context.SalesPersons.Remove(salesPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesPersonExists(int id)
        {
            return (_context.SalesPersons?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
