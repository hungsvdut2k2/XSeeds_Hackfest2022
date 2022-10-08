using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IExamStudentsRepository : IRepository<ExamStudent>
    {
        Task<ExamStudent> GetById(int id);
        Task<IEnumerable<ExamStudent>> GetByExam(int Exam_Id);
    }
}
