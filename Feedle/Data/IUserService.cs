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

        Task<bool> SubscribeToUser(UserSubscription userSubscription);

        Task<bool> UnsubscribeFromUser(int userId, int subscriptionId);

        Task<bool> MakeFriendRequestNotification(FriendRequestNotification friendRequestNotification);

        Task<bool> RespondToFriendNotification(bool status, FriendRequestNotification friendRequestNotification);

        Task<bool> AddConversation(int creatorId, int withWhomId, Conversation conversation);

        Task<bool> SendMessage(Message message);

        Task<List<FriendRequestNotification>> GetNotificationsUpdate(int lastNotificationId, int userId);

        Task<List<UserConversation>> GetMessageUpdate(int lastMessageId, int userId);

        Task<UserInformation> GetUserInformationById(int id);

        Task<bool> RemoveFriend(int id);

        int GetLastNotificationId();

        int GetLastMessageNotificationId();
        
        Task UpdateCurrentUser(User user);
        // Task saveCachedUser(User user);
        void RemoveCachedUser();
        // Task<User> getCachedUSer();
        
        Task<bool> RemoveUser(int userId);
    }
}