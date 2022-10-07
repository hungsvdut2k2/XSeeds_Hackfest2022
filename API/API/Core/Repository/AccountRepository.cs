using API.Core.IRepository;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Core.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context)
        {

        }
        public async Task<Account> GetAccountByEmail(string email)
        {
            return await _context.Accounts.FirstOrDefaultAsync(account => account.Email == email);
        }
    }
}
