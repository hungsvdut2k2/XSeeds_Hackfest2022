using API.Models;
using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IStudentRepository: IRepository<Student>
    {
        Task<Student> GetStudentById(int id);

    }
}
