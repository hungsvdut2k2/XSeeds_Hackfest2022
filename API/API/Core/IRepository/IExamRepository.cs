using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IExamRepository : IRepository<Exam>
    {
        Task<Exam> GetExamByIdAsync(int Exam_Id);
        Task<IEnumerable<Exam>> GetExamByUnit(int Unit_Id);
        Task<IEnumerable<Exam>> GetExamByStudent(int Student_Id);
    
    }

}
