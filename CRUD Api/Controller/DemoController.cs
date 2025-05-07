using CRUD_Api.DB;
using CRUD_Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly dbcontext _dbcontext;

        public DemoController(dbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost("AddStudent")]

        public async Task<IActionResult> AddStudent([FromBody] crudclass cd)
        {
            var add = new crudclass
            {
                //Id = cd.Id,
                Name = cd.Name,
                Fathername = cd.Fathername,
                Dateofbirth = cd.Dateofbirth,
            };
            _dbcontext.Add(add);
            await _dbcontext.SaveChangesAsync();


            return Ok("Student  Added SuccessFully");

        }
        [HttpGet("ShowStudentData")]

        public async Task<IActionResult> AddStudnet()
        {
            var data = await _dbcontext.Data.ToListAsync();
            return Ok(data);
        }
        [HttpDelete("DeleteStudentData")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var data = await _dbcontext.Data.FirstOrDefaultAsync(n => n.Id == id);

            _dbcontext.Data.Remove(data);
            await _dbcontext.SaveChangesAsync();

            return Ok("Student Deleted Successfully");
        }
        [HttpPut("UpdateStudetData")]
        public async Task<IActionResult> UpdateStudentData(int id, [FromBody]crudclass put)
        {
            var data = await _dbcontext.Data.FirstOrDefaultAsync(n =>n.Id == id);

            data.Name = put.Name;
            data.Fathername = put.Fathername;
            data.Dateofbirth = put.Dateofbirth;

            _dbcontext.Data.Update(data);
            await _dbcontext.SaveChangesAsync();

            return Ok("Student Data is Updated");

        }

        //[HttpGet("SearchAnyStudent")]
        //public async Task<IActionResult> ShowTheStudentData(int id)
        //{
        //    var student = await _dbcontext.Data.FirstOrDefaultAsync(n => n.Id == id);

        //    if (student == null)
        //    {
        //        return NotFound($"Student with ID {id} not found.");
        //    }

        //    return Ok(student);
        //}
        [HttpGet("ShowData")]
        public async Task <IActionResult> showData(int id)
        {
             var data = _dbcontext.Data.FirstOrDefault(n=>n.Id== id);
            if(data == null)
            {
                return BadRequest("student not found");
            }
            return Ok(data);
        }

    }
}
