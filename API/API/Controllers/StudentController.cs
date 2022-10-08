using API.Models;
using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace API.Controllers
{
    [EnableCors("Allow CORS")]
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService )
        {
            this._studentService = studentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var result = await _studentService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("{Student_Id}")]
        public async Task<ActionResult<Student>> GetStudentById(int Student_Id)
        {
            return Ok(await _studentService.GetStudentById(Student_Id));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateStudent([FromBody] StudentDTO request)
        {

            Student student = await _studentService.GetStudentById(request.Student_Id);
            student.VietnameseName = request.VietnameseName;
            student.KatakanaName = request.KatakanaName;
            _studentService.Update(student);
            return Ok("Update Successfully");
        }
        [HttpDelete("{Student_Id}")]
        public async Task<ActionResult> DeleteStudent(int Student_Id)
        {
            var Student = await _studentService.GetStudentById(Student_Id);
            if (Student == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _studentService.Delete(Student);
            return Ok("Delete Successfully");

        }
        [HttpGet("/star")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStarOfStudents()
        {
            IEnumerable<Student> students = await _studentService.GetAllAsync();
            Student[] listStudent = students.ToArray();
            Student[] resList = listStudent.OrderByDescending(c => c.Star).ToArray();
            return Ok(resList);
        }
    }
}
