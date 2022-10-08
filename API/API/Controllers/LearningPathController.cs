using API.Data;
using API.Models.ModelDBs;
using API.Services;
using API.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/learning-path")]
    [ApiController]
    public class LearningPathController : ControllerBase
    {
        private readonly DataContext dataContext;
        public LearningPathController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningPath>>> GetAllPaths()
        {
            IEnumerable<LearningPath> res = dataContext.LearningPath.ToList();
            return Ok(res);
        }
        [HttpGet("{Level}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourseInPath(string Level)
        {
            IEnumerable<Course> res = dataContext.Courses.Where(w => w.Level == Level).ToList();
            return Ok(res);
        }
    }
}
