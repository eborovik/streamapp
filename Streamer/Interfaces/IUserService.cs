using System.Threading.Tasks;
using Streamer.Models;

namespace Streamer.Interfaces
{
    public interface IUserService
    {
        bool CheckUserExists(UserModel user);
        Task CreateUser(UserModel user);
        string AuthenticateUser(UserModel user);
    }
}
