using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment2.Data.Models;

namespace Assingment1.Persistence
{
    public class FileContext
    {
        // public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }

        //   private readonly string familiesFile = "families.json";

        public FileContext()
        {
            //  Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        public void AddAdult(Adult adult)
        {
            //Hvis der ikke er nogen i listen så bliver maxId = 0 og så ++, dermed giver det den første id = 1
            int maxId = 0;
            try
            {
                maxId = Adults.Max(a => a.Id);
            }
            catch (Exception e)
            {
            }

            adult.Id = ++maxId;
            Adults.Add(adult);
            SaveChanges();
        }

        public void RemoveAdult(int adultId)
        {
            var toRemove = Adults.First(t => t.Id == adultId);
            Adults.Remove(toRemove);
            SaveChanges();
        }

        private IList<T> ReadData<T>(string s)
        {
            Console.WriteLine("READ DATA");
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            /*
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }
            */

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}