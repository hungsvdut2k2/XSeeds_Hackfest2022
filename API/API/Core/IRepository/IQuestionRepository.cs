using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> GetById(int id);
        Task<IEnumerable<Question>> GetQuestionByExam(int id);


    }
}
