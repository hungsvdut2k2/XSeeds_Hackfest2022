using API.Data;
using API.Models;
using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services;
using API.Services.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Allow CORS")]
    [Route("api/unit")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;
        private readonly ITeacherService _teacherService;
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly DataContext _context;

        public UnitController(IUnitService unitService, ITeacherService teacherService, ICourseService courseService, IStudentService studentService, DataContext context)
        {
            this._unitService = unitService;
            _teacherService = teacherService;
            _courseService = courseService;
            _studentService = studentService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetAllUnits()
        {
            var result = await _unitService.GetAllAsync();
            return Ok(result);
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
            await _unitService.AddAsync(unit);
            if(unitRequest.Type == "Word")
            {
                WordUnit newWordUnit = new WordUnit 
                {
                    Unit = unit,
                    Word = null,
                    Star = unitRequest.Star,
                    Unit_Name = unitRequest.Unit_Name 
                };
                _context.WordUnits.Add(newWordUnit);
                _context.SaveChanges();
            }
            else if(unitRequest.Type == "Video")
            {
                VideoUnit newVideoUnit = new VideoUnit
                {
                    Unit = unit,
                    Star = unitRequest.Star,
                    VideoUrl = unitRequest.VideoUrl
                };
                _context.VideoUnits.Add(newVideoUnit);
                _context.SaveChanges();
            }
            else
            {
                GrammarUnit newGrammarUnit = new GrammarUnit
                {
                    Unit = unit,
                    Content = unitRequest.Content
                };
                _context.GrammarUnits.Add(newGrammarUnit);
                _context.SaveChanges();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUnit(UpdateUnitDTO request)
        {
            Unit unit = await _unitService.GetUnitById(request.Unit_Id);
            if(unit == null)
            {
                return NotFound();
            }
            unit.Star = request.Star;
            unit.Number = request.Number;
            unit.Type = request.Type;
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
        [HttpGet("course/{Course_Id}")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnitByCourse(int Course_Id)
        {
            return Ok(await _unitService.getUnitByCourse(Course_Id));
        }
        [HttpPut("finish-unit/{Student_Id}/{Unit_Id}")]
        public async Task<ActionResult> FinishUnit(int Student_Id, int Unit_Id)
        {
            Student student = await _studentService.GetStudentById(Student_Id);
            Unit unit = await _unitService.GetUnitById(Unit_Id);
            
            student.Star += unit.Star;
            _studentService.Update(student);
            return Ok();
        }
        [HttpGet("{Unit_Id}")]
        public async Task<ActionResult> GetUnitById(int Unit_Id)
        {
            Unit unit = await _unitService.GetUnitById(Unit_Id);
            if (unit.Type == "Grammar")
            {
                GrammarUnit grammarUnit = _context.GrammarUnits.Where(w => w.Unit_Id == Unit_Id).FirstOrDefault();
                return Ok(grammarUnit);
            }
            else if(unit.Type == "Video")
            {
                VideoUnit videoUnit = _context.VideoUnits.Where(w => w.Unit_Id == Unit_Id).FirstOrDefault();
                return Ok(videoUnit);
            }
            else
            {
                WordUnit wordUnit = _context.WordUnits.Where(w => w.Unit_Id == Unit_Id).FirstOrDefault();
                return Ok(wordUnit);
            }
        }
    }
}
