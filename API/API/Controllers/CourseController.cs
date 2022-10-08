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
        private readonly IMapper mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            this._courseService = courseService;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var result = mapper.Map<IEnumerable<CourseDTO>>(await _courseService.GetAllAsync());
            return Ok(result);
        }
        [HttpGet]
        [Route("Course/{Course_Id}")]
        [HttpPost("")]
        public async Task<ActionResult<Course>> GetCourseById(int Course_Id)
        {
            return Ok(await _courseService.GetCourseById(Course_Id));
        }
        public async Task<ActionResult> AddCourse([FromBody] CourseDTO courseDTO)
        {
            if (courseDTO == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = mapper.Map<Course>(courseDTO);
            await _courseService.AddAsync(course);
            return Ok("Successfully created");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCourse([FromBody] Course courseDTO)
        {
            if (courseDTO == null)
            {
                return BadRequest();
            }
            var course = mapper.Map<Course>(courseDTO);
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
