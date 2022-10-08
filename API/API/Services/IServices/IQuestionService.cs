using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAllAsync();
        Task<Question> AddAsync(Question question);
        Task<Question> GetQuestionById(int Question_Id);
        void Update(Question question);
        void Delete(Question question);
        Task<IEnumerable<Question>> getQuestionByExam(int Exam_Id);
    }
}
