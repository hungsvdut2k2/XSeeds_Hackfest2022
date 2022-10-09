using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using Microsoft.EntityFrameworkCore;

namespace API.Core.Repository
{
    public class KanjiRepository : Repository<Kanji>, IKanjiRepository
    {
        public KanjiRepository(DataContext context) : base(context)
        {
        }

        public async Task<Kanji> GetKanjById(int kanji_Id)
        {
            return await _context.Kanjis.FirstOrDefaultAsync(p => p.Word_Id == kanji_Id);
        }
    }
}
