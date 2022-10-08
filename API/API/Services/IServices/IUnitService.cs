using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IUnitService
    {
        Task<IEnumerable<Unit>> GetAllAsync();
        Task<Unit> AddAsync(Unit unit);
        Task<Unit> GetUnitById(int course_Id);
        void Update(Unit unit);
        void Delete(Unit unit_Id);
        Task<IEnumerable<Unit>> getUnitByCourse(int Course_Id);
    }
}
