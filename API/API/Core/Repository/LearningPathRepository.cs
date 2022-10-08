using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;

namespace API.Core.Repository
{
    public class LearningPathRepository : Repository<LearningPath>, ILearningPathRepository
    {
        public LearningPathRepository(DataContext context) : base(context)
        {

        }
    }
}
