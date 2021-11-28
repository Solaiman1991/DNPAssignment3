using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2.Data.Models;

namespace Assignment2.DataAccess
{
    public interface IUserDao
    {
        public IList<User> GetUsers();
        public User AddUser(User user);
        public  void RemoveUser(User user);
        public IList<User> Users { get; }

        public User ValidateUser(string username, string password);
    }
}