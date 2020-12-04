using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public class CloudUserService : IUserService
    {
        private HttpClient client;

        public CloudUserService()
        {
            client = new HttpClient();
        }


        public async Task<User> ValidateUser(string userName, string password)
        {
            string query = "?username=" + userName + "&password=" + password;
            string response = await client.GetStringAsync("http://localhost:5002/feedle/user" + query);

            try
            {
                User user = JsonSerializer.Deserialize<User>(response);
                if (user.UserName == "Username or Password is wrong")
                {
                    throw new Exception(user.UserName);
                }

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}