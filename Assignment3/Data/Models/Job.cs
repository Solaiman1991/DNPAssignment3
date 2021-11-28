using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment2.Data.Models
{
    public class Job
    {
        [Key]
        public int jobId { get; set; }
        //[JsonPropertyName("jobTitle")]
        public string JobTitle { get; set; }
        
       // [JsonPropertyName("salary")]
        public int? Salary { get; set; }
    }
}