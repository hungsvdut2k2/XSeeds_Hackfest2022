using API.Core.IRepository;
using API.Data;
using API.Models;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context)
        {
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(p => p.Student_Id == id);
        }
    }
}
