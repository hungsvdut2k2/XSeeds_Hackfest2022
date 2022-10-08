using API.Data;
using API.Models.ModelDBs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Allow CORS")]
    [Route("api/university")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly DataContext _context;
        public UniversitiesController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetAllUniversity()
        {
            var result = _context.Universities.ToList();
            return Ok(result);
        }
    }
}
