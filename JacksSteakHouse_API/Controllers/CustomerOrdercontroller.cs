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
    public class CustomerOrdercontroller : ControllerBase
    {
        private JacksSteakHouseContext _context;

        public CustomerOrdercontroller(JacksSteakHouseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomerOrder([FromForm] CustomerOrderEdit model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //map
            CustomerOrder customerOrder = new CustomerOrder
            {
                OrderDate = model.OrderDate,
                CustomerId = model.CustomerId,
                MenuItemId = model.MenuItemId
            };
            //add
            await _context.CustomerOrders.AddAsync(customerOrder);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerOrders()
        {
            var customerOrders = await _context.CustomerOrders.ToListAsync();
            return Ok(customerOrders);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetCustomerOrder(int id)
        {
            
            var customerOrder = await _context.CustomerOrders.SingleOrDefaultAsync(o => o.OrderId == id);
            if(customerOrder is null)
            {
                return BadRequest();
            }
            return Ok(customerOrder);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateCustomerOrder(int id, [FromForm] CustomerOrderEdit model)
        {
            if(!ModelState.IsValid)
            return BadRequest(ModelState);
            
            var customerOrderDb = await _context.CustomerOrders.SingleOrDefaultAsync(o => o.OrderId == id);
            
            if(customerOrderDb is null)
            {
                return BadRequest();
            }
            customerOrderDb.OrderDate = model.OrderDate;
            customerOrderDb.CustomerId = model.CustomerId;
            customerOrderDb.MenuItemId = model.MenuItemId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteCustomerOrder(int id)
        {
            var customerOrderDb = await _context.CustomerOrders.FirstOrDefaultAsync(o => o.OrderId == id);
            
            if(customerOrderDb is null)
            {
                return BadRequest();
            }
            
            _context.CustomerOrders.Remove(customerOrderDb);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet, Route("/PreviousOrders/{CustomerId}")]
        public async Task<IActionResult> GetCustomerOrders(int CustomerId)
        {
            var customerOrders = await _context.CustomerOrders
            .Include(co => co.Customer)
            .Include(co => co.MenuItem)
            .Where(co => co.CustomerId == CustomerId)
            .Select(co => new CustomerOrderListItem
            {
                OrderDate = co.OrderDate,
                CustomerFirstName = co.Customer.FirstName,
                CustomerLastName = co.Customer.LastName,
                MealName = co.MenuItem.MealName
            }).ToListAsync();

            if (customerOrders is null)
            {
                return NotFound();
            }

            return Ok(customerOrders);
        }
    }
}