﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using OrderApi.Data;
//using OrderApi.Model;

//namespace OrderApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class OrdersdbController : ControllerBase
//    {

//        // GET: api/Orders/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Order>> GetOrder(int id)
//        {
//            var order = await _context.Order.FindAsync(id);

//            if (order == null)
//            {
//                return NotFound();
//            }

//            return order;
//        }

//        // PUT: api/Orders/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutOrder(int id, Order order)
//        {
//            if (id != order.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(order).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!OrderExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Orders
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<Order>> PostOrder(Order order)
//        {
//            _context.Order.Add(order);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
//        }

//        // DELETE: api/Orders/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Order>> DeleteOrder(int id)
//        {
//            var order = await _context.Order.FindAsync(id);
//            if (order == null)
//            {
//                return NotFound();
//            }

//            _context.Order.Remove(order);
//            await _context.SaveChangesAsync();

//            return order;
//        }

//        private bool OrderExists(int id)
//        {
//            return _context.Order.Any(e => e.Id == id);
//        }
//    }
//}