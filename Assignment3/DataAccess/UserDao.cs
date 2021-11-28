using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.DataAccess
{
    public class UserDao : IUserDao
    {

        public UserDao()
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            //     User seeIfTroelsThere = databaseContext.Users.FirstOrDefault(user => user.UserName.Equals("Troels"));
            //     
            //     if (seeIfTroelsThere == null)
            //     {
            //         databaseContext.Users.Add(new User()
            //         {
            //             UserName = "Troels",
            //             Password = "Troels1",
            //             Role = new List<Role>() {new Role() {RoleName = "Admin"}}
            //         });
            //         databaseContext.Users.Add(new User()
            //         {
            //             Username = "Kasper",
            //             Password = "Kasper1",
            //         });
            //         databaseContext.SaveChanges(); 
            //     }
            //
        }

        public User ValidateUser(string userName, string password)
        {
            using DatabaseContext databaseContext = new DatabaseContext();
            User user1 = databaseContext.Users.FirstOrDefault(user2 =>user2.UserName.Equals(userName) && user2.Password.Equals(password));
            return user1;
        }
        
        
        
        public User AddUser(User user)
        {
            using DatabaseContext dbContext = new DatabaseContext();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
        
        
        public IList<User> GetUsers()
        {
            using DatabaseContext dbContext = new DatabaseContext();
            return dbContext.Users.ToList();
        }


        public void RemoveUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public IList<User> Users { get; }
    }
}