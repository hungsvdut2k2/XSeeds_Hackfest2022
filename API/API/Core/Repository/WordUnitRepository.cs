using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;

namespace API.Core.Repository
{
    public class WordUnitRepository : Repository<WordUnit>, IWordUnitRepository
    {
        public WordUnitRepository(DataContext context) : base(context)
        {

        }
    }
}
