using CRUD_Api.DB;       // Replace with your actual namespace
using CRUD_Api.Model;    // If needed
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Api.Controller  // Match this with your other controller's namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly dbcontext _db;

        public DepartmentController(dbcontext db)
        {
            _db = db;
        }

        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _db.Departments.ToListAsync();
            return Ok(departments);
        }
    }
}
