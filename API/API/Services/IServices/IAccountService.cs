using API.Models;

namespace API.Services
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> AddAsync(Account account);
        Task<Account> GetByEmail(string email);
        Task<bool> CheckExistEmail(string email);
        void Update(Account account);
        void Delete(Account account);
        public void CreatPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        
        public string CreateToken(Account account);
        public string CreateRandomToken();
    }
}
