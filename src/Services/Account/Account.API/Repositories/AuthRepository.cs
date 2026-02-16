using Account.API.Data;
using Account.API.Entities;
using Account.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Account.API.Repositories
{
    public class AuthRepository : IAuthRepository
    { 
        private readonly AccountDbContext _context;
        public AuthRepository(AccountDbContext context)
        {
            _context = context;
        }
        public async Task<string> RequestOtpAsync(string phoneNumber)
        {
            var user = _context.Users.AsNoTracking().FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            if (user == null)
            {
                user = new User
                {
                    PhoneNumber = phoneNumber
                };
                _context.Users.Add(user);
            }
            await _context.SaveChangesAsync();
            return "224466";
        }

        public async Task<User> GetUserAsync(string phoneNumber)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}