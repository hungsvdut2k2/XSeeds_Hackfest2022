using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseById(int id);
    }
}
