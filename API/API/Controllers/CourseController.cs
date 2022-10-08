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

        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var result = await _courseService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Course/{Course_Id}")]
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
