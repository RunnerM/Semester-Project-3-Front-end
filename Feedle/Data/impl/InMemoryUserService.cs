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

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "bob",
                    Password = "123",
                    SecurityLevel = "1"
                },
                new User
                {
                    UserName = "adam",
                    Password = "123",
                    SecurityLevel = "1"
                },
                new User
                {
                    UserName = "admin",
                    Password = "123",
                    SecurityLevel = "99"
                }
            }.ToList();
        }

        public User ValidateUser(string userName, string password)
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

            return first;
        }
    }
}