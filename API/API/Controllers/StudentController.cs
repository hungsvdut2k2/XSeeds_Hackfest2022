using API.Models;
using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var result = mapper.Map<IEnumerable<StudentDTO>>(await _studentService.GetAllAsync());
            return Ok(result);
        }
        [HttpGet]
        [Route("Student/{Student_Id}")]
        public async Task<ActionResult<Student>> GetStudentById(int Student_Id)
        {
            return Ok(await _studentService.GetStudentById(Student_Id));
        }
        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] StudentDTO StudentDTO)
        {
            if (StudentDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var Student = mapper.Map<Student>(StudentDTO);
            await _studentService.AddAsync(Student);
            return Ok("Successfully created");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateStudent([FromBody] Student StudentDTO)
        {
            if (StudentDTO == null)
            {
                return BadRequest();
            }
            var Student = mapper.Map<Student>(StudentDTO);
            _studentService.Update(Student);
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
    }
}
