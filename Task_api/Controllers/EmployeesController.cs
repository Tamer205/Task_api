using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_api.Data;
using Task_api.DTO;
using Task_api.Models;

namespace Task_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var emps = context.Employees.Select(e => new EmployeesDTO()
            {
                Name = e.Name,
                Salary=e.Salary,
                Id=e.Id
            });
            return Ok(emps);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var e = context.Employees.Find(id);
            return Ok(e);
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeDTO request)
        {
            Employee e = new Employee()
            {
                Name = request.Name,
                Salary = request.Salary
            };
            context.Employees.Add(e);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = context.Employees.Find(id);
            context.Employees.Remove(p);
            context.SaveChanges();
            return Ok();
        }
        [HttpPatch("")]
        public IActionResult UpDate(Employee p, int id)
        {
            var e = context.Employees.Find(id);
            e.Name = p.Name;
            context.SaveChanges();
            return Ok();

        }
    }
}
