using System;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        
        public Task<User> Login(string username, string passwork)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string passwork)
        {
            byte[] passworkHash, passwordSalt;
            CreatePasswordHash(passwork, out passworkHash, out passwordSalt);

            user.PasswordHash = passworkHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string passwork, out byte[] passworkHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passworkHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwork));
            }
        }

        public Task<bool> UserExists(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}