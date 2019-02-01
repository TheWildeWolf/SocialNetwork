using System;
using System.Threading.Tasks;
using Hadia.Core;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly HadiaContext _db;
        public AuthService(HadiaContext context)
        {
            _db = context;
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _db.Mem_Masters.AnyAsync(x => x.Email == email))
                return true;

            return false;
        }

        public async Task<bool> Update(Mem_Master User, string password, string newPassword = null)
        {

            if (!VerifyPasswordHash(password, User.PasswordHash, User.PasswordSalt))
                        return false;

            if (newPassword != null)
            {
                CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);
                User.PasswordHash = passwordHash;
                User.PasswordSalt = passwordSalt;
            }

            _db.Update(User);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<bool> ResetPassword(Mem_Master user, string password)
        {
            if (password != null)
            {
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            _db.Update(user);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Mem_Master> Login(string username, string password)
        {
            var user = await _db.Mem_Masters.FirstOrDefaultAsync(x => x.Email == username);
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }

        internal bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        internal void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        
    }
}
