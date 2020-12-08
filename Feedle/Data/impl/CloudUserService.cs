using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Models;


namespace Feedle.Data
{
    public class CloudUserService : IUserService
    {
        private HttpClient client;
        private List<User> users;
        private User currentUser;
        private Uri uri = new Uri("http://localhost:5002/feedle/user");

        public CloudUserService()
        {
            client = new HttpClient();
        }


        public async Task<User> ValidateUser(string userName, string password)
        {
            string query = "?username=" + userName + "&password=" + password;
            string response = await client.GetStringAsync(uri + query);

            try
            {
                User user = JsonSerializer.Deserialize<User>(response);
                if (user==null)
                {
                    throw new Exception("Username or Password not valid!");
                }
                currentUser = user;
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            string newsToSerialize = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                newsToSerialize,
                Encoding.UTF8,
                "application/json"
                );
            
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task<IList<User>> GetFirendsByUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetCurrentUser()
        {
            return currentUser;
        }
    }
}
