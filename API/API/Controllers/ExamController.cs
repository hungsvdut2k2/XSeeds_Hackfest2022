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

        public ExamController(IExamService examService)
        {
            this._examService = examService;
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
        [Route("Exam/{Unit_Id}")]
        public async Task<ActionResult<IEnumerable<Exam>>> getExamByUnit(int Unit_Id)
        {
            return Ok(await _examService.getExamByUnit(Unit_Id));
        }
        [HttpGet]
        [Route ("Exam/{Student_Id}")]
        public async Task<ActionResult<IEnumerable<Exam>>> getExamByStudent(int Student_Id)
        {
            var Result = await _examService.getExamByStudent(Student_Id);
            return Ok(Result);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateExam(UpdateExamDTO examDTO)
        {
            if(examDTO == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var exam = await _examService.GetExamById(examDTO.Exam_Id);
            if(exam == null)
            {
                return NotFound();
            }
            exam.Exam_Name = examDTO.Exam_Name;
            exam.Question = examDTO.Question;
            exam.AnswerB = examDTO.AnswerB;
            exam.AnswerC = examDTO.AnswerC;
            exam.AnswerA = examDTO.AnswerA;
            exam.AnswerD = exam.AnswerD;
            exam.Answer = exam.Answer;
            _examService.Update(exam);        
            return Ok();
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
                Exam_Name = examDTO.Exam_Name,
                Question = examDTO.Question,
                AnswerA = examDTO.AnswerA,
                AnswerB = examDTO.AnswerB,
                AnswerC = examDTO.AnswerC,
                AnswerD = examDTO.AnswerD,
                Answer = examDTO.Answer,
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

    }
}
