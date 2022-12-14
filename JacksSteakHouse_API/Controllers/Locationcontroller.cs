using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JacksSteakHouse_API.DTOs;
using JacksSteakHouse_API.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JacksSteakHouse_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Locationcontroller : ControllerBase
    {
        private JacksSteakHouseContext _context;

        public Locationcontroller(JacksSteakHouseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostLocation([FromForm] LocationEdit model)
        {
            //check if the 'model' has all necessary data....
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            //Todo: manual mapping LocationEdit type to Location type...
            Location location = new Location{
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                GrandOpening = model.GrandOpening
            };

            //add to the database
            await _context.Locations.AddAsync(location);
            //save to the database
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            // var locations = await _context.Locations.ToListAsync();
            var locations = await _context.Locations
            .Include(l => l.Employees)
            .Select(l => new LocationListItem
            {
                Address = l.Address,
                PhoneNumber = l.PhoneNumber,
                Employees = l.Employees.Select(e => new EmployeeListItem
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName
                }).ToList()
            }).ToListAsync();
            return Ok(locations);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if(location is null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLocation(int id,[FromForm] LocationEdit model) //added [FromForm]
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var locationInDb = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if(locationInDb is null)
            {
                return NotFound();
            }
            //Re-write data here
            locationInDb.Address = model.Address;
            locationInDb.PhoneNumber = model.PhoneNumber;
            locationInDb.GrandOpening = model.GrandOpening;

            //save to db
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var locationInDb = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if(locationInDb is null)
            {
                return NotFound();
            }

            _context.Locations.Remove(locationInDb);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}