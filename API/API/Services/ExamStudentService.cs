using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class ExamStudentService : IExamStudentService
    {
        private readonly IExamStudentsRepository examStudentsRepository;

        public ExamStudentService(IExamStudentsRepository examStudentsRepository)
        {
            this.examStudentsRepository = examStudentsRepository;
        }

        public Task<IEnumerable<ExamStudent>> GetExamStudentsByExam(int Exam_Id)
        {
            return examStudentsRepository.GetByExam(Exam_Id);
        }
        public async Task<ExamStudent> AddAsync(ExamStudent examStudent)
        {
            await examStudentsRepository.AddAsync(examStudent);
            examStudentsRepository.Save();
            return examStudent;
        }
    }
}
