using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2.Data.Models;

namespace Assignment2.Persistence
{
    public interface IAdultFileContext
    {
        public Task<IList<Adult>> Getadults();
        public Task<Adult> AddAdult(Adult adult);
       public  void RemoveAdult(Adult adult);
       public IList<Adult> Adults { get; }

        public Adult GetByAdultId(int id);
        
       public Task EditAdult(Adult adult);
        public void UpdateAdult(Adult adultToUpdate);
    }
}