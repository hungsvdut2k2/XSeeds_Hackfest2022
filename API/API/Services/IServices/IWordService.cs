using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IWordService
    {
        Task<IEnumerable<Word>> GetAllAsync();
        Task<Word> AddAsync(Word word);
        Task<Word> GetWordById(int word);
        void Update(Word word);
        void Delete(Word word);
        Task<IEnumerable<Word>> getWordByUnit(int Unit_Id);
    }
}
