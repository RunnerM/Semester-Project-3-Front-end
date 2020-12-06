using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}