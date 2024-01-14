using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealerShip.Models;
using DealerShip.Presistance;
using DealerShip.DTOs.GetDTOs;
using DealerShip.DTOs.PostDTOs;

namespace DealerShip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SalesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Sales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleReadDto>>> GetSales()
        {
			var sale = await _context.Sales
					.Include(v => v.Vehicle)
					.Include(v => v.Customer)
					.Include(v => v.SalesPerson)
					.Select(v => new SaleReadDto
					{
						SaleID = v.TransactionID,
						Customer = v.Customer,
						SalesPerson = v.SalesPerson,
						SaleDate = v.TransactionDate,
						Vehicle = new VehicleSaleReadDto
						{
							VehicleID = v.VehicleID,
							VehicleMake = v.Vehicle.VehicleMake,
							VehicleModel = v.Vehicle.VehicleModel,
							VehicleSalePrice = v.Vehicle.VehicleSalePrice
						},

					})
					.ToListAsync();

			return sale;
		}

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleReadDto>> GetSale(int id)
        {
          if (_context.Sales == null)
          {
              return NotFound();
          }
			var sale = await _context.Sales
                     .Where(v => v.TransactionID == id)
					 .Include(v => v.Vehicle)
					 .Include(v => v.Customer)
					 .Include(v => v.SalesPerson)
					 .Select(v => new SaleReadDto
					 {
						 SaleID = v.TransactionID,
						 Customer = v.Customer,
						 SalesPerson = v.SalesPerson,
						 SaleDate = v.TransactionDate,
						 Vehicle = new VehicleSaleReadDto
						 {
							 VehicleID = v.VehicleID,
							 VehicleMake = v.Vehicle.VehicleMake,
							 VehicleModel = v.Vehicle.VehicleModel,
							 VehicleSalePrice = v.Vehicle.VehicleSalePrice
						 },

					 })
					 .FirstOrDefaultAsync();

            if(sale == null)
            {
                return NotFound();
            }

			return sale;

        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(int id, SaleCreateDto saleDto)
        {
			if (_context.Sales == null)
			{
				return Problem("Entity set 'ApplicationDBContext.Rents'  is null.");
			}

			var saleCustomer = await _context.Customers.FindAsync(saleDto.CustomerID);
			var saleVehicle = await _context.Vehicles.FindAsync(saleDto.VehicleID);
			var saleSalesPerson = await _context.SalesPersons.FindAsync(saleDto.SalesPersonID);
			if (saleCustomer == null || saleVehicle == null || saleSalesPerson == null)
			{
				BadRequest("Please Check the added data");
			}
			var sale = new Sale
			{
				TransactionAmount = saleDto.TransactionAmount,
				Vehicle = saleVehicle,
				VehicleID = saleDto.VehicleID,
				CustomerID = saleDto.CustomerID,
				Customer = saleCustomer,
				SalesPersonID = saleDto.SalesPersonID,
				SalesPerson = saleSalesPerson,
				TransactionDate = saleDto.TransactionDate,
			};

			_context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(SaleCreateDto saleDto)
        {
          if (_context.Sales == null)
          {
              return Problem("Entity set 'ApplicationDBContext.Sales'  is null.");
          }
			var saleCustomer = await _context.Customers.FindAsync(saleDto.CustomerID);
			var saleVehicle = await _context.Vehicles.FindAsync(saleDto.VehicleID);
			var saleSalesPerson = await _context.SalesPersons.FindAsync(saleDto.SalesPersonID);
			if (saleCustomer == null || saleVehicle == null || saleSalesPerson == null)
			{
				BadRequest("Please Check the added data");
			}
			var sale = new Sale
			{
				TransactionAmount = saleDto.TransactionAmount,
				Vehicle = saleVehicle,
				VehicleID = saleDto.VehicleID,
				CustomerID = saleDto.CustomerID,
				Customer = saleCustomer,
				SalesPersonID = saleDto.SalesPersonID,
				SalesPerson = saleSalesPerson,
				TransactionDate = saleDto.TransactionDate,
			};
			_context.Sales.Add(sale);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetSale", new { id = sale.TransactionID }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            if (_context.Sales == null)
            {
                return NotFound();
            }
            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleExists(int id)
        {
            return (_context.Sales?.Any(e => e.TransactionID == id)).GetValueOrDefault();
        }
    }
}
