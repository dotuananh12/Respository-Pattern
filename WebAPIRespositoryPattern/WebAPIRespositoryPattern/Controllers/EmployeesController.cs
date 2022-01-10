using DAL;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using System.Collections.Generic;

namespace WebAPIRespositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRespository _employeeRespository;

        public EmployeesController(IEmployeeRespository employeeRespository)
        {
            _employeeRespository = employeeRespository;
        }

        [HttpGet]
        public ActionResult<Employee> GetEmployees()
        {                    
            return Ok(_employeeRespository.GetEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRespository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee ko được trống");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Employee ko hợp lệ");
            }
            _employeeRespository.CreateEmployee(employee);
            return Ok(CreatedAtRoute("Id", new { id = employee.Id }, employee));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee ko duoc rong nhe");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Employee ko hop le ne");
            }
            var dbemp = _employeeRespository.GetEmployee(id);
            if (!dbemp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRespository.UpdateEmployee(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var dbemp = _employeeRespository.GetEmployee(id);
            if(!dbemp.Id.Equals(id))
            {
                return NotFound();
            }
            _employeeRespository.DeleteEmployee(dbemp);
            return NoContent();
        }
    }
}