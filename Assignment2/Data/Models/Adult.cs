
using System.Text.Json.Serialization;

namespace Assignment2.Data.Models
{
    
    public class Adult : Person
    {
        public Job job { get; set; }
        
    }
}