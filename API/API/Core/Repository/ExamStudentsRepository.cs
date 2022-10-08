using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class ExamStudentsRepository : Repository<ExamStudent>, IExamStudentsRepository
    {
        public ExamStudentsRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ExamStudent>> GetByExam(int Exam_Id)
        {
            return await _context.ExamStudents.Where(p => p.Examp_Id == Exam_Id).ToListAsync();
        }

        public async Task<ExamStudent> GetById(int id)
        {
            return await _context.ExamStudents.FirstOrDefaultAsync(p => p.ExemStudent_Id == id);
        }
    }
}
