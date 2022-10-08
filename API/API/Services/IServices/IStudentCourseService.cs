using API.Models;
using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IStudentCourseService
    {
        Task<IEnumerable<StudentsCourses>> GetAllAsync();
        Task<StudentsCourses> AddAsync(StudentsCourses account);
        Task<IEnumerable<StudentsCourses>> GetByStudentId(int Student_Id);
        Task<IEnumerable<StudentsCourses>> GetByCourseId(int Course_Id);
        Task<bool> CheckExistObject(int Account_Id, int Course_Id);
        void Update(StudentsCourses studentsCourses);
    }
}
