using API.Core.IRepository;
using API.Models;
using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }
        public async Task<Course> AddAsync(Course Course)
        {
            await _courseRepository.AddAsync(Course);
            _courseRepository.Save();
            return Course;
        }

        public void Delete(Course course)
        {
            _courseRepository.Delete(course);
            _courseRepository.Save();
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public Task<Course> GetCourseById(int course_Id)
        {
            return _courseRepository.GetCourseById(course_Id);
        }

        public void Update(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
