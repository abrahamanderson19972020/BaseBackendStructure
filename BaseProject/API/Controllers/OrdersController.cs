using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // Get Requests
        [HttpGet("getallorders")]
        public IActionResult GetAllOrders()
        {
            var result = _orderService.GetAllOrders();
            if(result.Success) return Ok(result);
            return BadRequest(result.Message);  
        }
        [HttpGet("getsingleorder")]
        public IActionResult GetSingleOrder(int orderId)
        {
            var result = _orderService.GetOrder(orderId);
            if(result.Success) return Ok(result);
            return NotFound(result.Message);
        }

        //Post Requests
        [HttpPost("add")]
        public IActionResult AddNewOrder(Order order)
        {
            var result = _orderService.Add(order);
            if (result.Success) return Ok(order);
            return BadRequest(result.Message);  
        }
        [HttpPost("update")]
        public IActionResult UpdateOrder(Order order)
        {
            var result = _orderService.Update(order);
            if(result.Success) return Ok(order);
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult DeleteOrder(Order order)
        {
            var result = _orderService.Delete(order);
            if(result.Success) return Ok(order);
            return BadRequest(result.Message);
        }

    }
}
