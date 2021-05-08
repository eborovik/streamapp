using System.Threading.Tasks;
using Streamer.Models;

namespace Streamer.Interfaces
{
    public interface IUserService
    {
        public bool CheckUserExists(UserModel user);
        public Task CreateUser(UserModel user);
        public string AuthenticateUser(UserModel user);
    }
}
