using API.Core.Repository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class WordUnitService : IWordUnitService
    {
        private readonly WordUnitRepository _wordUnitRepository;
        public async Task<WordUnit> AddAsync(WordUnit wordUnit)
        {
            return await _wordUnitRepository.AddAsync(wordUnit);
        }
    }
}
