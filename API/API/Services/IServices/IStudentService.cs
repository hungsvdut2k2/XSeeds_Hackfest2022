using API.Models;
using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> AddAsync(Student student);
        Task<Student> GetStudentById(int student_Id);
        void Update(Student student);
        void Delete(Student student);
    }
}
