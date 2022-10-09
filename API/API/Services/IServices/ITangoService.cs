using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface ITangoService
    {
        Task<IEnumerable<Tango>> GetAllAsync();
        Task<Tango> AddAsync(Tango tango);
        Task<Tango> GetTangoById(int Tango_Id);
        void Update(Tango tango);
        void Delete(Tango tango);
    }
}
