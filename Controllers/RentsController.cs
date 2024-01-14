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
    public class RentsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public RentsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentReadDto>>> GetRents()
        {
            var rents = await _context.Rents
                  .Include(v => v.Vehicle)
                  .Include(v => v.Customer)
                  .Include(v => v.SalesPerson)
                  .Select(v => new RentReadDto
                  {
                      RentID = v.TransactionID,
                      Customer = v.Customer,
                      SalesPerson = v.SalesPerson,
                      StartDate = v.TransactionDate,
                      EndDate = v.EndDate,
                      Vehicle = new VehicleRentReadDto
                      {
                          VehicleID = v.VehicleID,
                          VehicleMake = v.Vehicle.VehicleMake,
                          VehicleModel = v.Vehicle.VehicleModel,
                          VehicleRentPrice = v.Vehicle.VehicleRentPrice
                      },
                      TotalRentPrice = v.GetRentalDurationInDays() * v.Vehicle.VehicleRentPrice

                  })
                  .ToListAsync();

            return rents;
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RentReadDto>> GetRent(int id)
        {
            var rents = await _context.Rents
                    .Where(v => v.TransactionID == id)
                   .Include(v => v.Vehicle)
                   .Include(v => v.Customer)
                   .Include(v => v.SalesPerson)
                   .Select(v => new RentReadDto
                   {
                       RentID = v.TransactionID,
                       Customer = v.Customer,
                       SalesPerson = v.SalesPerson,
                       StartDate = v.TransactionDate,
                       EndDate = v.EndDate,
                       Vehicle = new VehicleRentReadDto
                       {
                           VehicleID = v.VehicleID,
                           VehicleMake = v.Vehicle.VehicleMake,
                           VehicleModel = v.Vehicle.VehicleModel,
                           VehicleRentPrice = v.Vehicle.VehicleRentPrice
                       },
                       TotalRentPrice = v.GetRentalDurationInDays() * v.Vehicle.VehicleRentPrice

                   })
                   .FirstOrDefaultAsync();

            if (rents == null)
            {
                return NotFound();
            }

            return rents;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(int id, RentCreateDto rentDto)
        {
			if (_context.Rents == null)
			{
				return Problem("Entity set 'ApplicationDBContext.Rents'  is null.");
			}

			var rentCustomer = await _context.Customers.FindAsync(rentDto.CustomerID);
			var rentVehicle = await _context.Vehicles.FindAsync(rentDto.VehicleID);
			var rentSalesPerson = await _context.SalesPersons.FindAsync(rentDto.SalesPersonID);
			if (rentCustomer == null || rentVehicle == null || rentSalesPerson == null)
			{
				BadRequest("Please Check the added data");
			}
			var rent = new Rent
			{
				TransactionAmount = rentDto.TransactionAmount,
				Vehicle = rentVehicle,
				VehicleID = rentDto.VehicleID,
				CustomerID = rentDto.CustomerID,
				Customer = rentCustomer,
				SalesPersonID = rentDto.SalesPersonID,
				SalesPerson = rentSalesPerson,
				TransactionDate = rentDto.TransactionDate,
				EndDate = rentDto.EndDate,
				InsuranceAmount = rentDto.InsuranceAmout
			};

			_context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent>> PostRent(RentCreateDto rentDto)
        {
            if (_context.Rents == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Rents'  is null.");
            }

            var rentCustomer = await _context.Customers.FindAsync(rentDto.CustomerID);
            var rentVehicle = await _context.Vehicles.FindAsync(rentDto.VehicleID);
            var rentSalesPerson = await _context.SalesPersons.FindAsync(rentDto.SalesPersonID);
            if (rentCustomer == null || rentVehicle == null || rentSalesPerson == null)
            {
                BadRequest("Please Check the added data");
            }
            var rent = new Rent
            {
                TransactionAmount = rentDto.TransactionAmount,
                Vehicle = rentVehicle,
                VehicleID = rentDto.VehicleID,
                CustomerID = rentDto.CustomerID,
                Customer = rentCustomer,
                SalesPersonID = rentDto.SalesPersonID,
                SalesPerson = rentSalesPerson,
                TransactionDate = rentDto.TransactionDate,
                EndDate = rentDto.EndDate,
                InsuranceAmount = rentDto.InsuranceAmout
            };
            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent", new { id = rent.TransactionID }, rent);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            if (_context.Rents == null)
            {
                return NotFound();
            }
            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentExists(int id)
        {
            return (_context.Rents?.Any(e => e.TransactionID == id)).GetValueOrDefault();
        }
    }
}
