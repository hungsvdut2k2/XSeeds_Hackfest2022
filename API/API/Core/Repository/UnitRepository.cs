using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        public UnitRepository(DataContext context) : base(context)
        {
        }

        public async Task<Unit> GetUnitById(int Id)
        {
            return await _context.Units.FirstOrDefaultAsync(p => p.Unit_Id == Id);
        }

        public async Task<IEnumerable<Unit>> GetUnitByIdCourse(int Course_Id)
        {
            return await _context.Units.Where(p => p.Course_Id == Course_Id).ToListAsync();
        }
    }
}
