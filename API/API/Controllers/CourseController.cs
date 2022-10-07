using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IStudentCourseService _studentCourseService;

        public CourseController(ICourseService courseService, IStudentCourseService studentCourseService)
        {
            this._courseService = courseService;
            this._studentCourseService = studentCourseService;
        }
        [HttpGet("student/{Student_Id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllRegisterdCourse(int Student_Id)
        {
            IEnumerable<StudentsCourses> middle_object = await _studentCourseService.GetByStudentId(Student_Id);
            List<Course> courses = new List<Course>();
            foreach(var item in middle_object)
            {
                courses.Add(item.Course);
            }
            return Ok(courses);
        }
        [HttpGet("student/completed/{Student_Id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCompletedCourse(int Student_Id)
        {
            IEnumerable<StudentsCourses> middle_object = await _studentCourseService.GetByStudentId(Student_Id);
            List<Course> completedCourses = new List<Course>();
            foreach(var item in middle_object)
            {
                if(item.Finish_At != null)
                {
                    completedCourses.Add(item.Course);
                }
            }
            return Ok(completedCourses);
        }
        [HttpGet("student/star/{Student_Id}")]
        public async Task<ActionResult<int>> GetStarsOfStudent(int Student_Id)
        {
            IEnumerable<StudentsCourses> middle_object = await _studentCourseService.GetByStudentId(Student_Id);
            int totalStar = 0;
            foreach (var item in middle_object)
            {
                if (item.Finish_At != null)
                {
                    totalStar += item.Star_Get_From_Course;
                }
            }
            return Ok(totalStar);
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var result = await _courseService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("{Course_Id}")]
        public async Task<ActionResult<Course>> GetCourseById(int Course_Id)
        {
            return Ok(await _courseService.GetCourseById(Course_Id));
        }
        [HttpPost("")]

        public async Task<ActionResult> AddCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _courseService.AddAsync(course);
            return Ok("Successfully created");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest();
            }
            _courseService.Update(course);
            return Ok("Update Successfully");
        }
        [HttpDelete("{Course_Id}")]
        public async Task<ActionResult> DeleteCourse(int Course_Id)
        {
            var course = await _courseService.GetCourseById(Course_Id);
            if (course == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _courseService.Delete(course);
            return Ok("Delete Successfully");
        }

    }
}
