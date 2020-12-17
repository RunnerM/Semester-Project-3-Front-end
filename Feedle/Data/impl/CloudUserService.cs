using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Feedle.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Feedle.Data
{
    public class CloudUserService : IUserService
    {
        public User CurrentUser { get; set; }
        public HttpClient Client { get; set; }
        
        public int LastMessageId { get; set; }
        
        public int LastNotificationId { get; set; }
        public CloudUserService()
        {
            Client = new HttpClient();
            Client.Timeout = TimeSpan.FromMilliseconds(Timeout.Infinite);
            LastMessageId = 0;
            LastNotificationId = 0;
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            string message =
                await Client.GetStringAsync("http://localhost:5002/feedle/user?username=" + userName + "&password=" + password);
            Console.WriteLine(message);
            try
            {
                CurrentUser = JsonSerializer.Deserialize<User>(message);
                return CurrentUser;
            }
            catch (Exception e)
            {
                throw new Exception("Invalid username or password");
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
            string result  = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool>(result);
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
        
        public async Task<UserInformation> GetUserInformationById(int id)
        {
            string message =  await Client.GetStringAsync("http://localhost:5002/feedle/user/userinfo?id="+id);
            if (message.Length==0)
            {
                return new UserInformation();
            }
            return JsonSerializer.Deserialize<UserInformation>(message);
        }

        public async Task<bool> SubscribeToUser(UserSubscription userSubscription)
        {
            string userSubToSerialize = JsonSerializer.Serialize(userSubscription);
            Console.WriteLine(userSubToSerialize);
            StringContent stringContent = new StringContent(
                userSubToSerialize,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage httpResponseMessage= await Client.PatchAsync("http://localhost:5002/feedle/user/subscribe", stringContent);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UnsubscribeFromUser(int userId, int subscriptionId)
        {
            HttpResponseMessage httpResponseMessage = 
                await Client.DeleteAsync("http://localhost:5002/feedle/user/unsubscribe?userId="+userId+"&subscriptionId=" + subscriptionId);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> MakeFriendRequestNotification(FriendRequestNotification friendRequestNotification)
        {
            string friendNotSerialize = JsonSerializer.Serialize(friendRequestNotification);
            Console.WriteLine(friendNotSerialize);
            StringContent stringContent = new StringContent(
                friendNotSerialize,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage httpResponseMessage= await Client.PostAsync("http://localhost:5002/feedle/user/makeFriendRequest", stringContent);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> RespondToFriendNotification(bool status, FriendRequestNotification friendRequestNotification)
        {
            string friendNotSerialize = JsonSerializer.Serialize(friendRequestNotification);
            Console.WriteLine(friendNotSerialize);
            StringContent stringContent = new StringContent(
                friendNotSerialize,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage httpResponseMessage= await Client.PatchAsync("http://localhost:5002/feedle/user/respondToFriendNotification?status="+status.ToString().ToLower(), stringContent);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> AddConversation(int creatorId, int withWhomId, Conversation conversation)
        {
            string conversationToSerialize = JsonSerializer.Serialize(conversation);
            Console.WriteLine(conversationToSerialize);
            StringContent stringContent = new StringContent(
                conversationToSerialize,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage httpResponseMessage= await Client.PostAsync("http://localhost:5002/feedle/user/conversation?creatorId="+creatorId+"&withWhomId="+withWhomId, stringContent);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> SendMessage(Message message)
        {
            string messageToSerialize = JsonSerializer.Serialize(message);
            Console.WriteLine(messageToSerialize);
            StringContent stringContent = new StringContent(
                messageToSerialize,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage httpResponseMessage= await Client.PostAsync("http://localhost:5002/feedle/sendMessage", stringContent);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public async Task<List<FriendRequestNotification>> GetNotificationsUpdate(int lastNotificationId, int userId)
        {
            String userNotifications = await Client.GetStringAsync(
                "http://localhost:5002/feedle/getFriendNotifications?lastNotificationId=" + lastNotificationId + "&userId" +
                userId);
            List<FriendRequestNotification> friendRequestNotificationsResult =
                JsonSerializer.Deserialize<List<FriendRequestNotification>>(userNotifications);
            if ( friendRequestNotificationsResult!= null)
            {
                LastNotificationId = CurrentUser.FriendRequestNotifications[Index.End].FriendRequestId;
                return friendRequestNotificationsResult;
            }

            return CurrentUser.FriendRequestNotifications;
        }

        public async Task<List<UserConversation>> GetMessageUpdate(int lastMessageId, int userId)
        {
            /*String userConversations = await Client.GetStringAsync(
                "http://localhost:5002/feedle/getMessages?lastMessageId=" + lastMessageId + "&userId" +
                userId);
            List<UserConversation> userConversationsResult =
                JsonSerializer.Deserialize<List<UserConversation>>(userConversations);
            if ( userConversationsResult!= null)
            {
                LastMessageId = GetLastMessageId(userConversationsResult); 
                return userConversationsResult;
            }

            return CurrentUser.UserConversations;
            */
            
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5002/feedle/getMessages?lastMessageId=" + lastMessageId + "&userId=" +
                                                                 userId);
            using (var response = await Client.SendAsync(
                request, 
                HttpCompletionOption.ResponseHeadersRead))
            {
                using (var body = await response.Content.ReadAsStreamAsync())
                using (var reader = new StreamReader(body))
                    while (!reader.EndOfStream)
                        Console.WriteLine(reader.ReadLine());
                return null;
            }
        }

        public int GetLastNotificationId()
        {
            return LastNotificationId;
        }

        public int GetLastMessageNotificationId()
        {
            return LastMessageId;
        }

        public async Task<bool> RemoveFriend(int id)
        {
            HttpResponseMessage httpResponseMessage = 
                await Client.DeleteAsync("http://localhost:5002/feedle/deleteFriend?userFriendId="+id);
            return httpResponseMessage.IsSuccessStatusCode;
        }

        private int GetLastMessageId(List<UserConversation> userConversations)
        {
            int max = -1;
            foreach (var userConversation in userConversations)
            {
                foreach (var message in userConversation.Conversation.Messages)
                {
                    if (message.Id > max)
                    {
                        max = message.Id;
                    }
                }
            }
            return max;
        }
        public async Task<bool> RemoveUser(int userId)
        {
            HttpResponseMessage httpResponseMessage = await Client.DeleteAsync("http://localhost:5002/feedle/user?Id=" +userId);
            return httpResponseMessage.IsSuccessStatusCode;;
        }
    }
}
