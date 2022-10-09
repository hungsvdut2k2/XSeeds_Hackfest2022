using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Core.Repository
{
    public class TangoRepository : Repository<Tango>, ITangoRepository
    {
        public TangoRepository(DataContext context) : base(context)
        {
        }

        public async Task<Tango> GetTangoByIdAsync(int id)
        {
            return await _context.Tangos.FirstOrDefaultAsync(p=> p.Word_Id == id);
        }
    }
}
