using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IKanjiRepository : IRepository<Kanji>

    {
        Task<Kanji> GetKanjById(int kanji_Id);
    }
}
