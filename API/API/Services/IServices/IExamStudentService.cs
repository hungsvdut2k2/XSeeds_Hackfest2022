using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IExamStudentService
    {
        Task<IEnumerable<ExamStudent>> GetExamStudentsByExam(int Exam_Id);
        Task<ExamStudent> AddAsync(ExamStudent examStudent);

    }
}
