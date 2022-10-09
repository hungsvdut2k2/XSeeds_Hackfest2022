using API.Models.ModelDBs;

namespace API.Core.IRepository
{
    public interface ITangoRepository : IRepository<Tango>
    {
        Task<Tango> GetTangoByIdAsync(int id);
    }
}
