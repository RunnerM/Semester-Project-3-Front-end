using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);

        Task<bool> RegisterUser(User user);

        Task<User> GetCurrentUser();

        Task<IList<User>> GetFriendsByUserId();
        
        Task UpdateCurrentUser(User user);
        // Task saveCachedUser(User user);
        // Task removeCachedUser();
        // Task<User> getCachedUSer();
    }
}