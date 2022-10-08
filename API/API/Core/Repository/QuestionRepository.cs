using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(DataContext context) : base(context)
        {
        }

        public Task<Question> GetById(int id)
        {
            return _context.Questions.FirstOrDefaultAsync(p=> p.Question_Id == id);
        }

        public async Task<IEnumerable<Question>> GetQuestionByExam(int Exam_Id)
        {
            return await _context.Questions.Where(p => p.Examp_Id == Exam_Id).ToListAsync();
        }
    }
}
