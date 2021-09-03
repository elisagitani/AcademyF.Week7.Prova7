using AcademyF.Week7.Prova7.Core.Entities;
using AcademyF.Week7.Prova7.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyF.Week7.Prova7.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMainBusinessLayer mainBL;
        public OrderController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        [HttpGet]
        public IActionResult FetchBooks()
        {
            var results = this.mainBL.FetchAllOrders();

            return Ok(results);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order id");

            var result = this.mainBL.GetOrderById(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (order == null)
                return BadRequest("Invalid Order Data");

            bool result = this.mainBL.CreateOrder(order);

            if (!result)
                return StatusCode(500, "Cannot create order");

            return CreatedAtAction(nameof(Get), new { Id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public IActionResult PutOrderById(int id, Order editedOrder)
        {
            if (id <= 0 || editedOrder == null)
                return BadRequest("Invalid Parameters");

            if (id != editedOrder.Id)
                return BadRequest("Order Id do not match");

            bool result = this.mainBL.UpdateOrder(editedOrder);

            if (!result)
                return StatusCode(500, "Cannot update order");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order Id");

            bool result = this.mainBL.DeleteOrderById(id);

            if (!result)
                return StatusCode(500, "Cannot delete order");

            return Ok(result);
        }

        [HttpGet("{id}/customer")]
        public IActionResult GetOrderByCustomer(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Customer id");

            var result = this.mainBL.GetOrdersByCustomerId(id);

            return Ok(result);
        }
    }
}
