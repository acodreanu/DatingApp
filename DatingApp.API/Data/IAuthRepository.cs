using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IAuthRepository
    {
         Task<User> Register(User user, string passwork);
         Task<User> Login(string username, string passwork);
         Task<bool> UserExists(string username);
         
    }
}