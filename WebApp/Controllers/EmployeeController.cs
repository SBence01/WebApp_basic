using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain.Entities;

namespace WebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeController(AppDbContext appDbContext) => _appDbContext = appDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _appDbContext.Employees;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Employee?>> GetById(int id) 
        {
            return await _appDbContext.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Employee employee)
        {
            _appDbContext.Employees.Update(employee);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeGetByIdResult = await GetById(id);
            if (employeeGetByIdResult.Value is null)
                return NotFound();

            _appDbContext.Remove(employeeGetByIdResult.Value);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
