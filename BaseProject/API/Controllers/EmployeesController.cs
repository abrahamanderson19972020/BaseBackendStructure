using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService; 
        }

        // Get Requests
        [HttpGet("getallemployees")]
        public IActionResult GetAllEmployee()
        {
            var result = _employeeService.GetEmployees();
            if(result.Success) return Ok(result);
            return BadRequest(result.Message);  
        }
        [HttpGet("getsingleemployee")]
        public IActionResult GetSingleEmployee(int employeeId)
        {
            var result = _employeeService.GetEmployee(employeeId);
            if(result.Success) return Ok(result);
            return NotFound(result.Message);
        }
        //Post Requests
        [HttpPost("add")]
        public IActionResult AddEmployee(Employee employee)
        {
            var result = _employeeService.Add(employee);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("update")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var result = _employeeService.Update(employee);
            if (result.Success) return Ok(result);
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult DeleteEmployee(Employee employee)
        {
            var result = _employeeService.Delete(employee);
            if (result.Success) return Ok(employee);
            return BadRequest(result.Message);  
        }
    }
}
