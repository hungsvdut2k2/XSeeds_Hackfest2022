using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface IUniversityService
    {
        Task<University> GetUniversityById(int University_Id);
    }
}
