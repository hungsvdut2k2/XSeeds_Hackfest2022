using API.Models;
using API.Models.ModelDBs;

namespace API.Services.IServices
{
    public interface ILearningPathService
    {
        Task<IEnumerable<LearningPath>> GetAllAsync();
        Task<LearningPath> AddAsync(LearningPath learningPath);
        Task<IEnumerable<LearningPath>> GetLearningPathById(int id);
    }
}
