using API.Core.Repository;
using API.Models;

namespace API.Core.IRepository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccountByEmail(string email);
    }
}
