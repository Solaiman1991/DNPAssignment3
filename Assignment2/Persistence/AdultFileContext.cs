using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment2.Data.Models;

namespace Assignment2.Persistence
{
    public class AdultFileContext : IAdultFileContext
    {
        public IList<Adult> Adults { get; private set; }
        private string adultsFile = "adults.json";


        public AdultFileContext()
        {
            if (!File.Exists(adultsFile))
            {
                WriteAdultToFile();
            }
            else
            {
                string content = File.ReadAllText(adultsFile);
                Adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }


        public async Task<Adult> AddAdult(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            WriteAdultToFile();
            return adult;
        }


        public Adult GetByAdultId(int id)
        {
            {
                foreach (Adult item in Adults)
                {
                    if (item.Id == id)
                    {
                        Adult adult = item;
                        return adult;
                    }
                }

                return null;
            }
        }

        public Task EditAdult(Adult adult)
        {
            //TODO
            
            return null;
        }


        public void RemoveAdult(Adult adult)
        {
            Adults.Remove(adult);
            {
                try
                {
                    Adult adultToRemove = Adults.First(a => a.Id == adult.Id);
                }
                catch (Exception e)
                {
                }
            }

            WriteAdultToFile();
        }


        public async void UpdateAdult(Adult adultToUpdate)
        {
            foreach (var item in Adults)
            {
                if (item.Id == adultToUpdate.Id)
                {
                    item.Update(adultToUpdate);
                }
            }
        }


        public async Task<IList<Adult>> Getadults()
        {
            List<Adult> tmp = new List<Adult>(Adults);
            return tmp;
        }


        private void WriteAdultToFile()
        {
            string adultAsJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, adultAsJson);
        }
    }
}