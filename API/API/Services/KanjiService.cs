using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;
using System.Linq.Expressions;

namespace API.Services
{
    public class KanjiService : IKanjiService
    {
        private readonly IKanjiRepository kanjiRepository;

        public KanjiService(IKanjiRepository kanjiRepository)
        {
            this.kanjiRepository = kanjiRepository;
        }

        public async Task<Kanji> AddAsync(Kanji kanji)
        {
            await kanjiRepository.AddAsync(kanji);
            kanjiRepository.Save();
            return kanji;
        }

        public void Delete(Kanji kanji)
        {
            kanjiRepository.Delete(kanji);
            kanjiRepository.Save();
        }

        public async Task<IEnumerable<Kanji>> GetAllAsync()
        {
          return await  kanjiRepository.GetAllAsync();
         }

        public Task<Kanji> GetKanjiById(int Kanji_Id)
        {
            return kanjiRepository.GetKanjById(Kanji_Id);
        }

        

        public void Update(Kanji kanji)
        {
            kanjiRepository.Update(kanji);
            kanjiRepository.Save();
        }
    }
}
