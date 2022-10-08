using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IExamService
    {

        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam> AddAsync(Exam exam);
        Task<Exam> GetExamById(int exam_Id);
        void Update(Exam exam);
        void Delete(Exam exam);
        Task<IEnumerable<Exam>> getExamByUnit(int Unit_Id);

        Task<IEnumerable<Exam>> getExamByStudent(int Student_Id);

    }
}
