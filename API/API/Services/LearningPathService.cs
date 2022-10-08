using API.Core.IRepository;
using API.Models.ModelDBs;
using API.Services.IServices;

namespace API.Services
{
    public class LearningPathService : ILearningPathService
    {
        private readonly ILearningPathRepository _learningPathRepository;
        public LearningPathService(ILearningPathRepository learningPathRepository)
        {
            _learningPathRepository = learningPathRepository;
        }

        public async Task<LearningPath> AddAsync(LearningPath learningPath)
        {
            return await _learningPathRepository.AddAsync(learningPath);
        }

        public async Task<IEnumerable<LearningPath>> GetAllAsync()
        {
            return await _learningPathRepository.GetAllAsync();
        }

        public async Task<IEnumerable<LearningPath>> GetLearningPathById(int id)
        {
            return await _learningPathRepository.SearchAsync(w => w.Path_Id == id);
        }
    }
}
