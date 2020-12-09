using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public class InMemoryUserService : IUserService
    {
        public List<User> users { get; set; }
        public User CurrentUser { get; set; }

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "bob",
                    Password = "123",
                    SecurityLevel = 1
                },
                new User
                {
                    UserName = "adam",
                    Password = "123",
                    SecurityLevel = 1
                },
                new User
                {
                    UserName = "bob2",
                    Password = "123",
                    SecurityLevel = 1
                },
                new User
                {
                    UserName = "adam2",
                    Password = "123",
                    SecurityLevel = 1
                }
            }.ToList();
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));

            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            CurrentUser = first;

            return first;
        }

        public Task<bool> RegisterUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUser(string username, string password, string securityLevel)
        {
            User newuser = new User();
            newuser.UserName = username;
            newuser.Password = password;
            newuser.SecurityLevel = 1;
            users.Add(newuser);
            //this wil work with file
        }

        public async Task<IList<User>> GetFirendsByUserId()
        {
            return users;
        }
        
        public async Task<User> UpdateCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCurrentUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetCurrentUser()
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetFriendsByUserId()
        {
            throw new NotImplementedException();
        }
    }
}