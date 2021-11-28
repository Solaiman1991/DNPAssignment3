using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Data.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.DataAccess
{
    public class AdultDao:IAdultDao
    {
        public IList<Adult> Getadults()
        {
            using DatabaseContext dbContext = new DatabaseContext();
            return dbContext.Adults.Include(adult => adult.job).ToList();
        }

        public Adult AddAdult(Adult adult)
        {
            using DatabaseContext dbContext = new DatabaseContext();
            dbContext.Adults.Add(adult);
            dbContext.SaveChanges();
            return adult;
        }

        public void RemoveAdult(int id)
        {
            using DatabaseContext dbContext = new DatabaseContext();
          
            Adult adult = dbContext.Adults.FirstOrDefault(adult => adult.Id == id);
            dbContext.Remove(adult);
            dbContext.SaveChanges();

        }
        
        public Adult GetByAdultId(int id)
        {
            using DatabaseContext dbContext = new DatabaseContext();
            return dbContext.Adults.First(adult => adult.Id == id);
            
        }

        
        public void UpdateAdult(Adult adultToUpdate)
        {
            using DatabaseContext dbContext = new DatabaseContext();
            dbContext.Adults.Update(adultToUpdate);
            dbContext.SaveChanges();

        }
    }
}