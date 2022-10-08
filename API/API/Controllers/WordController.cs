using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;
        private readonly IStudentService _studentService;
        private readonly IUnitService _unitService;

        public WordController(IWordService wordService, IStudentService studentService, IUnitService unitService)
        {
            this._wordService = wordService;
            this._studentService = studentService;
            this._unitService = unitService;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWordsAsync()
        {
            return Ok(await _wordService.GetAllAsync());
        }
        //[HttpPost]
        //public async Task<ActionResult> AddWord([FromBody]WordDTO wordRequest)
        //{
        //    if(wordRequest == null)
        //    {
        //        return BadRequest();

        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(); 
        //    }
        //    var unit = _unitService.GetUnitById(wordRequest.Unit_Id);
        //    var student = _studentService.GetStudentById(wordRequest.Student_Id);
        //    var word = new Word
        //    {
        //        Unit_Id = wordRequest.Unit_Id,
        //        Student_Id = wordRequest.Student_Id,    

        //    };
    }


}
        
