using API.Core.IRepository;
using API.Core.Repository;
using API.Models;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class StudentService :IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }
        public async Task<Student> AddAsync(Student Student)
        {
            await _studentRepository.AddAsync(Student);
            _studentRepository.Save();
            return Student;
        }

        public void Delete(Student Student)
        {
            _studentRepository.Delete(Student);
            _studentRepository.Save();
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public Task<Student> GetStudentById(int Student_Id)
        {
            return _studentRepository.GetStudentById(Student_Id);
        }

        public void Update(Student Student)
        {
            _studentRepository.Update(Student);
            _studentRepository.Save();
        }
    }
}
