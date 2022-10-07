using API.Core.IRepository;
using API.Core.Repository;
using API.Models;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            await _teacherRepository.AddAsync(teacher);
            _teacherRepository.Save();
            return teacher;
        }

        public void Delete(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher> GetTeacherById(int teacher_id)
        {
            return await _teacherRepository.GetTeacherById(teacher_id);
        }

        public void Update(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
            _teacherRepository.Save();
        }
    }
}
