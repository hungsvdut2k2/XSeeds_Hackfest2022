using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Allow CORS")]
    [Route("api/word")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;
        private readonly IStudentService _studentService;
        private readonly IUnitService _unitService;
        private readonly IKanjiService kanjiService;
        private readonly ITangoService tangoService;

        public WordController(IWordService wordService, IStudentService studentService, IUnitService unitService,IKanjiService kanjiService,ITangoService tangoService)
        {
            this._wordService = wordService;
            this._studentService = studentService;
            this._unitService = unitService;
            this.kanjiService = kanjiService;
            this.tangoService = tangoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWordsAsync()
        {
            return Ok(await _wordService.GetAllAsync());
        }
        [HttpGet("{word_Id}")]
        public async Task<ActionResult<IEnumerable<Word>>> GetWordsById(int word_Id)
        {
            return Ok(await _wordService.GetWordById(word_Id));
        }
        [HttpPost]
        public async Task<ActionResult> AddWord([FromBody] WordDTO wordRequest)
        {
            if (wordRequest == null)
            {
                return BadRequest();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var unit = _unitService.GetUnitById(wordRequest.Unit_Id);
            var word = new Word
            {
                Unit_Id = wordRequest.Unit_Id,
                Type = wordRequest.Type,
            };
            await _wordService.AddAsync(word);
            if(wordRequest.Type == "Kanji")
            {
                var kanji = new Kanji
                {
                    Kunyomi = wordRequest.Kunyomi,
                    Onyomi = wordRequest.Onyomi,
                    HanViet = wordRequest.HanViet,
                    Word_Kanji = wordRequest.Word_Kanji,
                };
                kanjiService.AddAsync(kanji);
                
            }
            if(wordRequest.Type == "Tango")
            {
                var tango = new Tango
                {
                    Word_Tango = wordRequest.Word_tango,
                    Pronounce = wordRequest.Pronounce,
                    Vietnamese_mean = wordRequest.VietNamese_mean,
                };
                await tangoService.AddAsync(tango);
                
            }
            return Ok();
        }
        [HttpDelete]
        [Route("Word/{Word_id}")]
        public async Task<ActionResult> deleteWord(int Word_id) {

            var wordDelete = await _wordService.GetWordById(Word_id);
            if(wordDelete == null)
            {
                return BadRequest();
            }
            _wordService.Delete(wordDelete);
            return Ok();

        }
        
        }


}
        
