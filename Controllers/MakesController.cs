using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DealerShip.Models;
using DealerShip.Presistance;
using DealerShip.DTOs;
using DealerShip.DTOs.GetDTOs;
using DealerShip.DTOs.PostDTOs;

namespace DealerShip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MakesController(ApplicationDBContext context)
        {
            _context = context;
        }

		// GET: api/Makes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<MakeReadDto>>> GetMakes()
		{
			var makes = await _context.Makes
				.Include(m => m.Models)
				.Select(m => new MakeReadDto
				{
					MakeID = m.MakeID,
					MakeName = m.MakeName,
					Models = m.Models.Select(model => new ModelReadDto
					{
						ModelID = model.ModelID,
						ModelName = model.ModelName
					}).ToList()
				}).ToListAsync();

			return makes;
		}

		// GET: api/Makes/5
		[HttpGet("{id}")]
		public async Task<ActionResult<MakeReadDto>> GetMake(int id)
		{
			var make = await _context.Makes
				.Include(m => m.Models)
				.Where(m => m.MakeID == id)
				.Select(m => new MakeReadDto
				{
					MakeID = m.MakeID,
					MakeName = m.MakeName,
					Models = m.Models.Select(model => new ModelReadDto
					{
						ModelID = model.ModelID,
						ModelName = model.ModelName
					}).ToList()
				})
				.FirstOrDefaultAsync();

			if (make == null)
			{
				return NotFound();
			}

			return make;
		}



		// PUT: api/Makes/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMake(int id, MakeReadDto makeDto)
		{
			if (id != makeDto.MakeID)
			{
				return BadRequest();
			}

			// Fetch the existing Make
			var make = await _context.Makes
				.Include(m => m.Models)
				.FirstOrDefaultAsync(m => m.MakeID == id);

			if (make == null)
			{
				return NotFound();
			}

			// Update Make properties
			make.MakeName = makeDto.MakeName;

			// Update Models
			foreach (var modelDto in makeDto.Models)
			{
				var model = make.Models.FirstOrDefault(m => m.ModelID == modelDto.ModelID);
				if (model == null)
				{
					// Add new model if it doesn't exist
					make.Models.Add(new Model { ModelName = modelDto.ModelName });
				}
				else
				{
					// Update existing model
					model.ModelName = modelDto.ModelName;
				}
			}

			// Optionally, handle removal of models no longer associated
			// ...

			_context.Entry(make).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MakeExists(id))
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


		// POST: api/Makes
		[HttpPost]
		public async Task<ActionResult<MakeReadDto>> PostMake(MakeCreateDto makeDto)
		{
			var make = new Make
			{
				MakeName = makeDto.MakeName,
				Models = makeDto.Models.Select(m => new Model { ModelName = m.ModelName }).ToList()
			};

			_context.Makes.Add(make);
			await _context.SaveChangesAsync();

			var makeReadDto = new MakeReadDto
			{
				MakeID = make.MakeID,
				MakeName = make.MakeName,
				Models = make.Models.Select(m => new ModelReadDto { ModelID = m.ModelID, ModelName = m.ModelName }).ToList()
			};

			return CreatedAtAction("GetMake", new { id = make.MakeID }, makeReadDto);
		}




		// DELETE: api/Makes/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            if (_context.Makes == null)
            {
                return NotFound();
            }
            var make = await _context.Makes.FindAsync(id);
            if (make == null)
            {
                return NotFound();
            }

            _context.Makes.Remove(make);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MakeExists(int id)
        {
            return (_context.Makes?.Any(e => e.MakeID == id)).GetValueOrDefault();
        }
    }
}
