using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }
        public async Task<Question> AddAsync(Question question)
        {
            await _questionRepository.AddAsync(question);
            _questionRepository.Save();
            return question;
        }

        public void Delete(Question question)
        {
            _questionRepository.Delete(question);
            _questionRepository.Save();
        }

        public Task<IEnumerable<Question>> GetAllAsync()
        {
            return _questionRepository.GetAllAsync();
        }

        public async Task<Question> GetQuestionById(int Question_Id)
        {
            return await _questionRepository.GetById(Question_Id);
        }


        public Task<IEnumerable<Question>> getQuestionByExam(int Exam_Id)
        {
            return _questionRepository.GetQuestionByExam(Exam_Id);
        }

        public void Update(Question question)
        {
            _questionRepository.Update(question);
            _questionRepository.Save();
        }

    }
}
