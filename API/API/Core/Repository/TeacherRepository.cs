using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class TeacherRepository : Repository<Teacher> , ITeacherRepository
    {
        public TeacherRepository(DataContext context) : base(context)
        {
        }

        public async Task<Teacher> GetTeacherById(int teacher_ID)
        {
            return await _context.Teachers.FirstOrDefaultAsync(p => p.Teacher_Id == teacher_ID);
        }
    }
}
