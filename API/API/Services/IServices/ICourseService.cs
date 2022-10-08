using API.Models;
using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> AddAsync(Course Course);
        Task<Course> GetCourseById(int course_Id);
        void Update(Course course);
        void Delete(Course course);
    }
}
