using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface IWordRepository : IRepository<Word>
    {
        Task<Word> GetWordById(int id);
        Task<IEnumerable<Word>> GetWordByUnit(int Unit_Id);
    }
}
