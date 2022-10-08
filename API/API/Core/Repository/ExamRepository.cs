using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(DataContext context) : base(context)
        {
        }

        public Task<Exam> GetExamByIdAsync(int Exam_Id)
        {
            return _context.Exams.FirstOrDefaultAsync(p => p.Exam_Id == Exam_Id);

        }

        public async Task<IEnumerable<Exam>> GetExamByStudent(int Student_Id)
        {
            return await _context.Exams.Where(p => p.Sudent_Id == Student_Id).ToListAsync();
        }

        public async Task<IEnumerable<Exam>> GetExamByUnit(int Unit_Id)
        {
            return await _context.Exams.Where(p => p.Unit_Id == Unit_Id).ToListAsync();
        }
    }
}
