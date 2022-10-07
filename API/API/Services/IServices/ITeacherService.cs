using API.Models;
using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> AddAsync(Teacher teacher);
        Task<Teacher> GetTeacherById(int teacher_id);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
    }
}
