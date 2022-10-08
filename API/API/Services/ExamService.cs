using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            this._examRepository = examRepository;
        }

        public async Task<Exam> AddAsync(Exam exam)
        {
           await _examRepository.AddAsync(exam);
            _examRepository.Save();
           return exam;
        }

        public void Delete(Exam exam)
        {
            _examRepository.Delete(exam);
            _examRepository.Save();
        }

        public Task<IEnumerable<Exam>> GetAllAsync()
        {
           return  _examRepository.GetAllAsync();
        }

        public async Task<Exam> GetExamById(int exam_Id)
        {
            return await _examRepository.GetExamByIdAsync(exam_Id);
        }

        public Task<IEnumerable<Exam>> getExamByStudent(int Student_Id)
        {
            return _examRepository.GetExamByStudent(Student_Id);
        }

        public Task<IEnumerable<Exam>> getExamByUnit(int Unit_Id)
        {
            return _examRepository.GetExamByUnit(Unit_Id);
        }

        public void Update(Exam exam)
        {
            _examRepository.Update(exam);
            _examRepository.Save();
        }
    }
}
