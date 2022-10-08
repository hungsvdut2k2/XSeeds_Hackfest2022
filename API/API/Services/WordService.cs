using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;

        public WordService(IWordRepository wordRepository)
        {
            this._wordRepository = wordRepository;
        }
        public async Task<Word> AddAsync(Word word)
        {
            await _wordRepository.AddAsync(word);
            _wordRepository.Save();
            return word;
        }

        public void Delete(Word word)
        {
            _wordRepository.Delete(word);
            _wordRepository.Save();
        }

        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _wordRepository.GetAllAsync();
         }

        public async Task<Word> GetWordById(int word_Id)
        {
            return await _wordRepository.GetWordById(word_Id);
        }

        public async Task<IEnumerable<Word>> getWordByUnit(int Unit_Id)
        {
            return await _wordRepository.GetWordByUnit(Unit_Id);
        }

        public async void Update(Word word)
        {
            _wordRepository.Delete(word);
            _wordRepository.Save();
        }
    }
}
