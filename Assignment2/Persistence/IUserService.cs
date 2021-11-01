using Assignment2.Data.Models;

namespace Assingment2.Persistence{
    
public interface IUserService {
    User ValidateUser(string userName, string password);
}
}