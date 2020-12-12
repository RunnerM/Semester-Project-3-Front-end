using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Models;
using Microsoft.AspNetCore.Mvc;


namespace Feedle.Data
{
    public class CloudUserService : IUserService
    {
        public User CurrentUser { get; set; }
        public HttpClient Client { get; set; }
        public CloudUserService()
        {
            Client = new HttpClient();
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            string message =
                await Client.GetStringAsync("http://localhost:5002/feedle/user?username=" + userName + "&password=" + password);
            Console.WriteLine(message);
            if (JsonSerializer.Deserialize<User>(message) == null)
            {
                CurrentUser = null;
                return null;
            }
            else
            {
                CurrentUser = JsonSerializer.Deserialize<User>(message);
                return CurrentUser;
            }
        }

        public async Task<bool> RegisterUser(User user)
        {
            string userToSerialize = JsonSerializer.Serialize(user);
            Console.WriteLine(userToSerialize);
            StringContent stringContent = new StringContent(
                userToSerialize,
                Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage responseMessage =
                await Client.PostAsync("http://localhost:5002/feedle/user", stringContent);
            return responseMessage.IsSuccessStatusCode;
        }

        public Task<IList<User>> GetFirendsByUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetCurrentUser()
        {
            if (CurrentUser != null)
            {
                return await ValidateUser(CurrentUser.UserName, CurrentUser.Password);
            }
            return null;
        }

        public async Task UpdateCurrentUser(User user)
        {
            string userToSerialize = JsonSerializer.Serialize(user);
            Console.WriteLine(userToSerialize);
            StringContent stringContent = new StringContent(
                userToSerialize,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage httpResponseMessage=
                await Client.PatchAsync("http://localhost:5002/feedle/user", stringContent);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ValidateUser(CurrentUser.UserName, CurrentUser.Password);
            }
        }

        public void RemoveCachedUser()
        {
            this.CurrentUser = null;
        }

        public Task<IList<User>> GetFriendsByUserId()
        {
            throw new NotImplementedException();
        }

        public async Task<UserInformation> GetUserInformationById(int id)
        {
            string message =  await Client.GetStringAsync("http://localhost:5002/feedle/user/userinfo?id="+id);
            if (message.Length==0)
            {
                return new UserInformation();
            }
            return JsonSerializer.Deserialize<UserInformation>(message);
        }
    }
}
