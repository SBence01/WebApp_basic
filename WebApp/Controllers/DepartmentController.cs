using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain.Entities;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public DepartmentController(AppDbContext appDbContext) => _appDbContext = appDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return _appDbContext.Departments;
        }

        [HttpGet("id")]
        public async Task<ActionResult<Department?>> GetById(int id) 
        {
            return await _appDbContext.Departments.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Department department)
        {
            await _appDbContext.Departments.AddAsync(department);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = department.Id }, department);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Department department)
        {
            _appDbContext.Departments.Update(department);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var departmentGetByIdResult = await GetById(id);
            if (departmentGetByIdResult.Value is null)
                return NotFound();

            _appDbContext.Remove(departmentGetByIdResult.Value);
            await _appDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
