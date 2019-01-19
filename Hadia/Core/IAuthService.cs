using System.Threading.Tasks;
using Hadia.Models.DomainModels;

namespace Hadia.Core
{
    public interface IAuthService
    {
        Task<Mem_Master> Login(string username, string password);
        Task<bool> UserExists(string email);
        Task<bool> Update(Mem_Master user, string password,string newPassword =null);
        Task<bool> ResetPassword(Mem_Master user, string password);
    }
}