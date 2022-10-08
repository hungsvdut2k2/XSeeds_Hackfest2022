using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IWordUnitService
    {
        Task<WordUnit> AddAsync(WordUnit wordUnit);
    }
}
