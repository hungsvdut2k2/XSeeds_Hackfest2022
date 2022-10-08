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
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly IExamService _examService;

        public QuestionController(IQuestionService questionService,IExamService examService)
        {
            this._questionService = questionService;
            this._examService = examService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> getAllQuestion()
        {

            var Result = await _questionService.GetAllAsync();
            return Ok(Result);
        }
        [HttpGet]
        [Route("{Question_Id}")]
        public async Task<ActionResult<Question>> getQuestionById(int Question_Id)
        {

            return Ok(await _questionService.GetQuestionById(Question_Id));
        }
        [HttpGet]
        [Route("{Exam_Id}")]
        public async Task<ActionResult<IEnumerable<Question>>> getQuestionByExam(int Exam_Id)
        {
            return Ok(await _questionService.getQuestionByExam(Exam_Id));
        }


        [HttpPut]
        public async Task<ActionResult> UpdateQuestion(QuestionDTOUpdate questionDTO)
        {
            if (questionDTO == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var question = await _questionService.GetQuestionById(questionDTO.Question_Id);
            if ( question== null)
            {
                return NotFound();
            }
            _questionService.Update(question);
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> AddQuestion(QuestionDTO questionDTO)
        {
            if (questionDTO == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var exam = await _examService.GetExamById(questionDTO.Examp_Id);
            if(exam == null)
            {
                return NotFound();
            }
            var question = new Question
            {
                Content = questionDTO.Content,
                Answer = questionDTO.Answer,
                AnswerA = questionDTO.AnswerA,
                AnswerB = questionDTO.AnswerB,
                AnswerC = questionDTO.AnswerC,
                AnswerD = questionDTO.AnswerD,
                Examp_Id = questionDTO.Examp_Id,
                Exam = exam

            };
            await _questionService.AddAsync(question);
            return Ok();
        }

        [HttpDelete("{question_Id}")]
        public async Task<ActionResult> DeleteQuestion(int question_Id)
        {
            var questionDelete = await _questionService.GetQuestionById(question_Id);
            if (questionDelete == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _questionService.Delete(questionDelete);
            return Ok();
        }
    }
}
