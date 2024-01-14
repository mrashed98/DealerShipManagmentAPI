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
using DealerShip.Migrations;

namespace DealerShip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public VehiclesController(ApplicationDBContext context)
        {
            _context = context;
        }

		// GET: api/Vehicles
		[HttpGet]
		public async Task<ActionResult<IEnumerable<VehicleReadDto>>> GetAllVehicles()
		{
			var vehicles = await _context.Vehicles
				.Include(v => v.VehicleStatus)
				.Include(v => v.VehicleImages)
				.Select(v => new VehicleReadDto
				{
					VehicleID = v.VehicleID,
					VehicleModel = v.VehicleModel,
					VehicleMake = v.VehicleMake,
					VehicleType = v.VehicleType,
					VehicleMileage = v.VehicleMileage,
					VehicleRentPrice = v.VehicleRentPrice,
					VehicleSalePrice = v.VehicleSalePrice,
					VehicleProductionDate = v.VehicleProductionDate,
					VehicleState = new VehicleStatusDto
					{
						Id = v.VehicleStatus.VehicleStatusID,
						Status = v.VehicleStatus.StatusName
					},
					VehicleImages = v.VehicleImages.Select(img => img.ImageUrl).ToList(),
				}).ToListAsync();

			return vehicles;
		}


		// GET: api/Vehicles/5
		[HttpGet("{id}")]
		public async Task<ActionResult<VehicleReadDto>> GetVehicle(int id)
		{
			var vehicle = await _context.Vehicles
				.Include(v => v.VehicleStatus)
				.Include(v => v.VehicleImages)
				.Where(v => v.VehicleID == id)
				.Select(v => new VehicleReadDto
				{
					VehicleModel = v.VehicleModel,
					VehicleMake = v.VehicleMake,
					VehicleType = v.VehicleType,
					VehicleMileage = v.VehicleMileage,
					VehicleRentPrice = v.VehicleRentPrice,
					VehicleSalePrice = v.VehicleSalePrice,
					VehicleProductionDate = v.VehicleProductionDate,
					VehicleState = new VehicleStatusDto
					{
						Id = v.VehicleStatus.VehicleStatusID,
						Status = v.VehicleStatus.StatusName
					},
					VehicleImages = v.VehicleImages.Select(img => img.ImageUrl).ToList()
				}).FirstOrDefaultAsync();

			if (vehicle == null)
			{
				return NotFound();
			}

			return vehicle;
		}

		// PUT: api/Vehicles/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutVehicle(int id, VehicleCreateDto vehicleDto)
		{
			var vehicle = await _context.Vehicles.FindAsync(id);
			if (vehicle == null)
			{
				return NotFound();
			}

			var vehicleState = await _context.VehicleStatuses.FirstOrDefaultAsync(v => v.StatusName == vehicleDto.VehicleStatusName);
			if (vehicleState == null)
			{
				_context.VehicleStatuses.Add(
					new VehicleStatus(vehicleDto.VehicleStatusName));
				await _context.SaveChangesAsync();
				vehicleState = await _context.VehicleStatuses.FirstOrDefaultAsync(v => v.StatusName == vehicleDto.VehicleStatusName);
			}

			// Update the properties of the vehicle from the DTO
			vehicle.VehicleModel = vehicleDto.VehicleModel;
			vehicle.VehicleMake = vehicleDto.VehicleMake;
			vehicle.VehicleType = vehicleDto.VehicleType;
			vehicle.VehicleMileage = vehicleDto.VehicleMileage;
			vehicle.VehicleRentPrice = vehicleDto.VehicleRentPrice;
			vehicle.VehicleSalePrice = vehicleDto.VehicleSalePrice;
			vehicle.VehicleProductionDate = vehicleDto.VehicleProductionDate;
			vehicle.VehicleStatus = vehicleState;

			// Update the entity in the context and save changes
			_context.Entry(vehicle).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				var v =  _context.Vehicles.Any(e => e.VehicleID == id);
				if (!v)
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


		// POST: api/Vehicles
		[HttpPost]
		public async Task<ActionResult<VehicleReadDto>> PostVehicle(VehicleCreateDto vehicleDto)
		{
			var vehicleStatus = await _context.VehicleStatuses.FirstOrDefaultAsync(v => v.StatusName == vehicleDto.VehicleStatusName);
			if (vehicleStatus == null)
			{
				_context.VehicleStatuses.Add(
					new VehicleStatus(vehicleDto.VehicleStatusName));
				await _context.SaveChangesAsync();
			}
			vehicleStatus = await _context.VehicleStatuses.FirstOrDefaultAsync(v => v.StatusName == vehicleDto.VehicleStatusName);

			var vehicle = new Vehicle
			{
				// Map the properties from the DTO to the Vehicle entity
				VehicleModel = vehicleDto.VehicleModel,
				VehicleMake = vehicleDto.VehicleMake,
				VehicleType = vehicleDto.VehicleType,
				VehicleMileage = vehicleDto.VehicleMileage,
				VehicleRentPrice = vehicleDto.VehicleRentPrice,
				VehicleSalePrice = vehicleDto.VehicleSalePrice,
				VehicleProductionDate = vehicleDto.VehicleProductionDate,
				VehicleStatusID = vehicleStatus.VehicleStatusID
			};

			_context.Vehicles.Add(vehicle);
			await _context.SaveChangesAsync();

			// Create a VehicleReadDto for the response (you may need to load related entities)
			var vehicleReadDto = new VehicleReadDto
			{
				VehicleModel = vehicleDto.VehicleModel,
				VehicleMake = vehicleDto.VehicleMake,
				VehicleType = vehicleDto.VehicleType,
				VehicleMileage = vehicleDto.VehicleMileage,
				VehicleRentPrice = vehicleDto.VehicleRentPrice,
				VehicleSalePrice = vehicleDto.VehicleSalePrice,
				VehicleProductionDate = vehicleDto.VehicleProductionDate,
				VehicleState = new VehicleStatusDto
				{
					Id = vehicleStatus.VehicleStatusID,
					Status = vehicleStatus.StatusName
				}
			};

			return CreatedAtAction("GetVehicle", new { id = vehicle.VehicleID }, vehicleReadDto);
		}


		// DELETE: api/Vehicles/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            if (_context.Vehicles == null)
            {
                return NotFound();
            }
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleExists(int id)
        {
            return (_context.Vehicles?.Any(e => e.VehicleID == id)).GetValueOrDefault();
        }
    }
}
