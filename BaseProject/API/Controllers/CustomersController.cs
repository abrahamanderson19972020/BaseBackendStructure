using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService; 
        }

        // Get Requests
        [HttpGet("getallcustomers")]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetCustomers();
            if(result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpGet("getsinglecustomer")]
        public IActionResult GetSingleCustomer(string customerId)
        {
            var result = _customerService.GetCustomer(customerId);
            if (result.Success) return Ok(result);
            return NotFound(result.Message);
        }

        //Post Requests
        [HttpPost("add")]
        public IActionResult AddCustomer(Customer customer)
        {
            var builder = new StringBuilder(5);
            Random _random = new Random();
             char offset = 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26

            for (var i = 0; i < 5; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            customer.CustomerId =  builder.ToString();
            var response = _customerService.Add(customer);
            if (response.Success) return Ok(response.Message);
            return BadRequest(response.Message);
        }
        [HttpPost("update")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            var response = _customerService.Update(customer);
            if (response.Success) return Ok(response.Message);
            return BadRequest(response.Message);
        }
        [HttpPost("delete")]
        public IActionResult DeleteCustomer(Customer customer)
        {
            var response = _customerService.Delete(customer);
            if (response.Success) return Ok(response.Message);
            return BadRequest(response.Message);
        }
    }
}
