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
    public class MenuItemcontroller : ControllerBase
    {
        private JacksSteakHouseContext _context;

        public MenuItemcontroller(JacksSteakHouseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMenuItems([FromForm ]MenuItemEdit model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var menuItem = new MenuItem
            {
                MealName = model.MealName,
                MealDescription = model.MealDescription,
                Price = model.Price
            };

            //add to db
            await _context.MenuItems.AddAsync(menuItem);
            //save to db
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetMenuItems()
        {
            var menuItems = await _context.MenuItems.ToListAsync();
            return Ok(menuItems);
        }
        
        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if(menuItem == null)
            {
                return NotFound();
            }
            return Ok(menuItem);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, [FromForm] MenuItemEdit model)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var menuItemDb = await _context.MenuItems.FindAsync(id);
            if(menuItemDb == null)
            {
                return NotFound();
            }

            menuItemDb.MealName = model.MealName;
            menuItemDb.MealDescription = model.MealDescription;
            menuItemDb.Price = model.Price;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var menuItemDb = await _context.MenuItems.FindAsync(id);
            if(menuItemDb == null)
            {
                return NotFound();
            }
            _context.MenuItems.Remove(menuItemDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}