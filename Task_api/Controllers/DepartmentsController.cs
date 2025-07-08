using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_api.Data;
using Task_api.DTO;
using Task_api.Models;

namespace Task_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var deps = context.Departments.Select(d => new DepartmentDTO()
            {
                Name = d.Name,
                Id = d.Id
            });
            return Ok(deps);
        }
        [HttpGet("{id}")]
        public IActionResult Details(int id)
        {
            var d = context.Departments.Find(id);
            return Ok(d);
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO request)
        {
            Department d = new Department()
            {
                Name = request.Name,
            };
            context.Departments.Add(d);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = context.Departments.Find(id);
            context.Departments.Remove(p);
            context.SaveChanges();
            return Ok();
        }
        [HttpPatch("")]
        public IActionResult UpDate(Department p, int id)
        {
            var d = context.Employees.Find(id);
            d.Name = p.Name;
            context.SaveChanges();
            return Ok();

        }
    }
}
