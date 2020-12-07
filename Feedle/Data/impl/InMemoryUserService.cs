using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;
        private User currentUser;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "bob",
                    Password = "123",
                    SecurityLevel = "admin"
                },
                new User
                {
                    UserName = "adam",
                    Password = "123",
                    SecurityLevel = "user"
                },
                new User
                {
                    UserName = "bob2",
                    Password = "123",
                    SecurityLevel = "admin"
                },
                new User
                {
                    UserName = "adam2",
                    Password = "123",
                    SecurityLevel = "user"
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

            currentUser = first;

            return first;
        }

        public async Task RegisterUser(string username, string password, string securityLevel)
        {
            User newuser = new User();
            newuser.UserName = username;
            newuser.Password = password;
            newuser.SecurityLevel = "user";
            users.Add(newuser);
            //this wil work with file
        }

        public async Task<IList<User>> GetFirendsByUserId()
        {
            return users;
        }

        public async Task<User> GetCurrentUser()
        {
            return currentUser;
        }
    }
}