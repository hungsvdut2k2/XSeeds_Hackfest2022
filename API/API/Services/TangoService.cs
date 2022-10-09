using API.Core.IRepository;
using API.Core.Repository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class TangoService : ITangoService 
    {
        private readonly ITangoRepository tangoRepository;

        public TangoService(ITangoRepository tangoRepository)
        {
            this.tangoRepository = tangoRepository;
        }
        public async Task<Tango> AddAsync(Tango tango)
        {
            await tangoRepository.AddAsync(tango);
            tangoRepository.Save();
            return tango;
        }

        public void Delete(Tango tango)
        {
            tangoRepository.Delete(tango);
            tangoRepository.Save();
        }

        public async Task<IEnumerable<Tango>> GetAllAsync()
        {
            return await tangoRepository.GetAllAsync();
        }

        public Task<Tango> GetTangoById(int tango_Id)
        {
            return tangoRepository.GetTangoByIdAsync(tango_Id);
        }



        public void Update(Tango tango)
        {
            tangoRepository.Update(tango);
            tangoRepository.Save();
        }
    }
}
