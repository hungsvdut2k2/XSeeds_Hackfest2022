using API.Core.IRepository;
using API.Data;
using API.Models.ModelDBs;
using System.Linq.Expressions;

namespace API.Core.Repository
{
    public class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(DataContext context) : base(context)
        {

        }
    }
}
