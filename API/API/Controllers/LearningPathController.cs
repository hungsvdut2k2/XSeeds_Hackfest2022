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
        [HttpGet("{Path_Id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourseInPath(int Path_Id)
        {
            IEnumerable<Course> res = dataContext.Courses.Where(w => w.Learning_Path_Id == Path_Id).ToList();
            return Ok(res);
        }
    }
}
