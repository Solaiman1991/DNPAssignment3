using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Assignment2.Data.Models {
public class Person :IPerson {
    
    [Required]
    [NotNull, Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    
   [JsonPropertyName("Id")] 
    public int Id { get; set; }
    
    //[JsonPropertyName("firstName")] 
    public string FirstName { get; set; }
    
    //[JsonPropertyName("lastName")] 
    public string LastName { get; set; }
    
    //[JsonPropertyName("hairColor")] 
    public string HairColor { get; set; }
    
    //[JsonPropertyName("eyecolor")] 
    public string EyeColor { get; set; }
    
    //[JsonPropertyName("age")] 
    public int Age { get; set; }
    
   // [JsonPropertyName("weight")] 
    public float Weight { get; set; }
    
    //[JsonPropertyName("height")] 
    public int Height { get; set; }
    
   //[JsonPropertyName("sex")] 
    public string Sex { get; set; }
    
    
    
    public void Update(Person toUpdate)
    {
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
        HairColor = toUpdate.LastName;
        EyeColor = toUpdate.EyeColor;
        Age = toUpdate.Age;
        Weight = toUpdate.Weight;
        Height = toUpdate.Height;
        Sex = toUpdate.Sex;
    }
}


}