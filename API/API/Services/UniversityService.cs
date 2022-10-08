using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _universityRepository;
        public async Task<University> GetUniversityById(int University_Id)
        {
            return await _universityRepository.FirstOrDefaultAsync(s=> s.University_Id == University_Id);
        }
    }
}
