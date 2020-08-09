using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNetCore.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        const string getOrder = "GetOrder";

        [HttpGet("{customerId}/orders")]
        public IActionResult GetOrders(int customerId)
        {
            var customer = Repository.Instance
                .Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer is null)
            {
                return NotFound();
            }
            if (customer.Orders is null)
            {
                return NotFound();
            }
            return Ok(customer.Orders);
        }

        [HttpGet("{customerId}/orders/{id}", Name = getOrder)]
        public IActionResult Get(int customerId, int id)
        {
            var customer = Repository.Instance
                .Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer is null)
            {
                return NotFound();
            }
            if (customer.Orders is null)
            {
                return NotFound();
            }
            var order = customer.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("{customerId}/orders")]
        public IActionResult CreateOrder(int customerId, [FromBody] OrderForCreateDTO order)
        {
            if (order is null)
            {
                return BadRequest();
            }

            var customer = Repository.Instance
                .Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer is null)
            {
                return NotFound();
            }

            int maxOrderId = Repository.Instance.Customers.SelectMany(c => c.Orders).Max(o => o.OrderId);
            OrderDTO orderDomain = order.ToDomain(maxOrderId);
            customer.Orders.Add(orderDomain);

            return CreatedAtRoute(getOrder,
                new { customerId = customerId, id = orderDomain.OrderId },
                orderDomain);
        }

        [HttpPut("{customerId}/orders/{id}")]
        public IActionResult UpdateOrder(int customerId, int id, [FromBody] OrderForUpdateDTO order)
        {
            if (order is null)
            {
                return BadRequest();
            }

            var customer = Repository.Instance
                .Customers.FirstOrDefault(c => c.Id == customerId);

            if (customer is null)
            {
                return NotFound();
            }

            if (customer.Orders is null)
            {
                return NotFound();
            }
            var orderDomain = customer.Orders.FirstOrDefault(o => o.OrderId == id);
            if (orderDomain is null)
            {
                return NotFound();
            }

            orderDomain.Update(order);
            return NoContent();
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
