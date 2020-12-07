using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);

        Task RegisterUser(string userName, string password, string securityLevel);

        Task<IList<User>> GetFirendsByUserId();

        Task<User> GetCurrentUser();
        // Task saveCachedUser(User user);
        // Task removeCachedUser();
        // Task<User> getCachedUSer();
    }
}