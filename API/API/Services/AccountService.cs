using API.Core.IRepository;
using API.Core.Repository;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Services
{
    public class AccountService :   IAccountService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;

        public AccountService(DataContext context,IConfiguration configuration,IAccountRepository accountRepository )
        {
            this._context = context;
            this._configuration = configuration;
            this._accountRepository = accountRepository;
        }
        

        public async Task<Account> AddAsync(Account account)
        {
            await _accountRepository.AddAsync(account);
            _accountRepository.Save();
            return account;

        }

        public async Task<bool> CheckExistEmail(string email)
        {
            return await _accountRepository.AnyAsync(account => account.Email == email);
        }

        public string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(8));
        }

        public string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,account.Email),
                new Claim(ClaimTypes.Role, account.Role)

            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public void CreatPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public void Delete(Account account)
        {
            _accountRepository.Delete(account);
            _accountRepository.Save();
        }

        

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account> GetByEmail(string username)
        {
            return await _accountRepository.GetAccountByEmail(username);
        }

        public Task<Account> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Update(Account account)
        {
            _accountRepository.Update(account);
            _accountRepository.Save();
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes((string)password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}

