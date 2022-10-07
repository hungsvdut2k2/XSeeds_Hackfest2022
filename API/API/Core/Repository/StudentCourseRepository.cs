using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;

namespace API.Core.Repository
{
    public class StudentCourseRepository : Repository<StudentsCourses>, IStudentCourseRepository
    { 
        public StudentCourseRepository(DataContext context) : base(context)
        {

        }
    }
}
