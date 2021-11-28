using System;
using System.Collections.Generic;
using System.Linq;
using Assignment2.Data.Models;

namespace Assignment2.Data {
public class InMemoryUserService : IUserService
{
    private List<User> users;

    public InMemoryUserService() {
        users = new[] {
            new User {
                UserName = "Student",
                Password = "123456",
                Role = "Teacher",
                SecurityLevel = 2
            },
            new User {
                UserName = "Admin",
                Password = "123456",
                Role = "Admin", 
                SecurityLevel = 3
            }
        }.ToList();
    }


    public User ValidateUser(string userName, string password) {
        User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
        if (first == null) {
            throw new Exception("User not found");
        }

        if (!first.Password.Equals(password)) {
            throw new Exception("Incorrect password");
        }

        return first;
    }
}
}