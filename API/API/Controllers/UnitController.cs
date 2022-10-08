using API.Models;
using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services;
using API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;

        public UnitController(IUnitService unitService, ITeacherService teacherService, ICourseService courseService)
        {
            this._unitService = unitService;
            _teacherService = teacherService;
            _courseService = courseService;
        }
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAllUnits()
        {
            var result = await _unitService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("Unit/{Unit_Id}")]
        public async Task<ActionResult<Unit>> GetUnitById(int Unit_Id)
        {
            return Ok(await _unitService.GetUnitById(Unit_Id));
        }
        [HttpPost]
        public async Task<ActionResult> AddUnit([FromBody] UnitDTO unitRequest)
        {
            if (unitRequest == null)
            {
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Teacher author = await _teacherService.GetTeacherById(unitRequest.Teacher_Id);
            Course course = await _courseService.GetCourseById(unitRequest.Course_Id);
            var unit = new Unit
            {
                Teacher = author,
                Course = course,
                Type = unitRequest.Type,
                Number = unitRequest.Number,
                Star = unitRequest.Star
            };
            _unitService.AddAsync(unit);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUnit(int Unit_Id,[FromBody] UnitDTO unitRequest)
        {
            if (unitRequest == null)
            {
                return BadRequest();
            }
            Unit unit = await _unitService.GetUnitById(Unit_Id);
            if(unit == null)
            {
                return NotFound();
            }
            unit.Unit_Id = Unit_Id;
            unit.Teacher_Id = unitRequest.Teacher_Id;
            unit.Course_Id = unitRequest.Course_Id;
            unit.Star = unitRequest.Star;
            _unitService.Update(unit);
            return Ok("Update Successfully");
        }
        [HttpDelete("{Unit_Id}")]
        public async Task<ActionResult> DeleteStudent(int Unit_Id)
        {
            var unit = await _unitService.GetUnitById(Unit_Id);
            if (unit == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitService.Delete(unit);
            return Ok("Delete Successfully");
        }
        [HttpGet("Units/{Course_Id}")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnitByCourse(int Course_Id)
        {
            return Ok(await _unitService.getUnitByCourse(Course_Id));
        }
    }
}
