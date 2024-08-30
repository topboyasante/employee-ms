using employee_ms.Data;
using employee_ms.Models.DTO;
using employee_ms.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace employee_ms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public EmployeeController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(dbContext.Employees.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            // the names "id" must match the route parameter name
            var res = dbContext.Employees.Find(id);

            if (res is null)
            {
                return NotFound();
            }

            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateEmployee(AddEmployeeDTO data)
        {
            var employee = new Employee()
            {
                Name = data.Name,
                Email = data.Email,
                Phone = data.Phone,
                Salary = data.Salary,
            };

            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO data)
        {
            var res = dbContext.Employees.Find(id);

            if (res is null)
            {
                return NotFound();
            }

            res.Name = data.Name;
            res.Email = data.Email;
            res.Phone = data.Phone;
            res.Salary = data.Salary;

            dbContext.SaveChanges();

            return Ok(data);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var res = dbContext.Employees.Find(id);

            if (res is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(res);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}