using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2.Data.Models;

namespace Assignment2.DataAccess
{
    public interface IAdultDao
    {
        public IList<Adult> Getadults();
        public Adult AddAdult(Adult adult);
        public  void RemoveAdult(int id);
        public Adult GetByAdultId(int id);
        public void UpdateAdult(Adult adultToUpdate);
    }
}