using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class WordRepository : Repository<Word>, IWordRepository
    {
        public WordRepository(DataContext context) : base(context)
        {
        }

        public async Task<Word> GetWordById(int id)
        {
            return await _context.Words.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Word>> GetWordByUnit(int Unit_Id)
        {
            return await _context.Words.Where(p => p.Unit_Id == Unit_Id).ToListAsync();
        }
    }
}
