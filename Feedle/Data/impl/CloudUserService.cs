using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Models;
using Microsoft.AspNetCore.Http;


namespace Feedle.Data
{
    public class CloudUserService 
    {
        private HttpClient client;
        Uri uri = new Uri("http://localhost:5002/feedle/user");

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
                if (user.UserName == null)
                {
                    throw new Exception("User not found");
                }

                if (!user.Password.Equals(password))
                {
                    throw new Exception("Incorrect password");
                }
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task RegisterUser(User user)
        {
            string sereliazedData = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                sereliazedData,
                Encoding.UTF8,
                "application/Json"
            );
            HttpResponseMessage response = await client.PostAsync(uri, content);
            

        }

        public async Task<IList<User>> GetFirendsByUserId(int id)
        {

            return null;

        }

        public async Task<bool> DeleteUser(int id)
        {
            string query = "?id=" + id;
            HttpResponseMessage response= await client.DeleteAsync(uri + query);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
