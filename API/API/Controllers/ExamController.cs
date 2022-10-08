using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Allow CORS")]
    [Route("api/exam")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly IUnitService unitService;
        private readonly IExamStudentService _examStudentService;

        public ExamController(IExamService examService,IUnitService unitService,IExamStudentService examStudentService)
        {
            this._examService = examService;
            this.unitService = unitService;
            this._examStudentService = examStudentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> getAllExam()
        {

            var Result = await _examService.GetAllAsync();
            return Ok(Result);
        }
        [HttpGet]
        [Route("{Exam_Id}")]
        public async Task<ActionResult<Exam>> getExamById(int Exam_Id) {

            return Ok(await _examService.GetExamById(Exam_Id));
        }
        [HttpGet]
        [Route("unit/{Unit_Id}")]
        public async Task<ActionResult<IEnumerable<Exam>>> getExamByUnit(int Unit_Id)
        {
            return Ok(await _examService.getExamByUnit(Unit_Id));
        }
        [HttpGet]
        [Route("finish_unit")]
        public async Task<ActionResult<IEnumerable<Unit>>> getCompleteUnit(int StudentId , int CourseId)
        {
            IEnumerable<Unit> listUnit = await unitService.getUnitByCourse(CourseId);
            List<Unit> result = new List<Unit>();
            foreach(var item in listUnit)
            {
                Exam exam = item.Exam;
                foreach(ExamStudent examStudent in exam.ExamStudents)
                {
                    if (examStudent.Student_Id == StudentId);
                    result.Add(item);
                    break;
                    
                }
            }
            return Ok(result);
        }
    
       


      
        [HttpPost]
        public async Task<ActionResult> AddExam(ExamDTO examDTO)
        {
            if (examDTO == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Exam = new Exam
            {
                Unit_Id = examDTO.Unit_Id,
               
            };
            await _examService.AddAsync(Exam);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteExam(int exam_Id)
        {
            var examDelete = await _examService.GetExamById(exam_Id);
            if(examDelete == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(); 
            }
            _examService.Delete(examDelete);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> AddExamStudent(int Examp_id,int student_id)
        {
            Exam exam = await _examService.GetExamById(Examp_id);
            ExamStudent examStudent = new ExamStudent
            {
                Student_Id = student_id,
                Exam = exam
            };
             await _examStudentService.AddAsync(examStudent);
            return Ok();
        }
        
    }
}
