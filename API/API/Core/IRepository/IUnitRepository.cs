using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IUnitRepository : IRepository<Unit>
    {
        Task<IEnumerable<Unit>> GetUnitByIdCourse(int Course_Id);
        Task<Unit> GetUnitById(int Id);
    }
}
