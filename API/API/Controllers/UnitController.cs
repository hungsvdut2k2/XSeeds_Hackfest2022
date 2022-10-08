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

        public UnitController(IUnitService unitService)
        {
            this._unitService = unitService;
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
            var unit = new Unit();
            unit.Unit_Id = unitRequest.Unit_Id;
            unit.Teacher_Id = unitRequest.Teacher_Id;
            unit.Course_Id = unitRequest.Course_Id;
            unit.Star = unitRequest.Star;
            await _unitService.AddAsync(unit);
            return Ok("Successfully created");
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUnit([FromBody] UnitDTO unitRequest)
        {
            if (unitRequest == null)
            {
                return BadRequest();
            }
            Unit unit = await _unitService.GetUnitById(unitRequest.Unit_Id);
            if(unit == null)
            {
                return NotFound();
            }
            unit.Unit_Id = unitRequest.Unit_Id;
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
        [HttpGet("Unit/{Couse_Id}")]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnitByCourse(int Couse_Id)
        {
            return Ok(await _unitService.getUnitByCourse(Couse_Id));
        }
    }
}
