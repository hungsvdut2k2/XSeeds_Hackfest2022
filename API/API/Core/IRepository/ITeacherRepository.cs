using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetTeacherById(int teacher_ID);
    }
}
