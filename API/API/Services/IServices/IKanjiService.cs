using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IKanjiService
    {
        Task<IEnumerable<Kanji>> GetAllAsync();
        Task<Kanji> AddAsync(Kanji Kanji);
        Task<Kanji> GetKanjiById(int Kanji_Id);
        void Update(Kanji kanji);
        void Delete(Kanji kanji);
    }
}
