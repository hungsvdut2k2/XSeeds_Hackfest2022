using API.Core.IRepository;
using API.Core.Repository;
using API.Data;
using API.Models;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class StudentCourseService : IStudentCourseService
    {
        private readonly DataContext _context;
        private readonly IStudentCourseRepository _studentCourseRepository;
        public StudentCourseService(DataContext context, IStudentCourseRepository studentCourseRepository)
        {
            this._context = context;
            _studentCourseRepository = studentCourseRepository;
        }
        public async Task<StudentsCourses> AddAsync(StudentsCourses studentsCourses)
        {
            await _studentCourseRepository.AddAsync(studentsCourses);
            _studentCourseRepository.Save();
            return studentsCourses;
        }

        public async Task<bool> CheckExistObject(int Account_Id, int Course_Id)
        {
            return await _studentCourseRepository.AnyAsync(sc => sc.Student_Id == Account_Id && sc.Course_Id == Course_Id);
        }

        public Task<IEnumerable<StudentsCourses>> GetAllAsync()
        {
            return _studentCourseRepository.GetAllAsync();
        }

        public async Task<IEnumerable<StudentsCourses>> GetByStudentId(int Student_Id)
        {
            return await _studentCourseRepository.SearchAsync(sc => sc.Student_Id == Student_Id);
        }

        public async void Update(StudentsCourses studentsCourses)
        {
            _studentCourseRepository.Update(studentsCourses);
            _studentCourseRepository.Save();
        }
    }
}
