

using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace testMVC.Models
    
{
    public class ListModel
    {
        //Properies
        [Required] 
        public string? name { get; set; }
       
        [Required]
        public string? todo { get; set; }
        [JsonPropertyName("time")]
        [Required]
        public int? time { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ListModel>(this);


        public ListModel()
        {
            name = "hasse";
            todo =  "clean";
            time = 10;


        }
    }

   
  
 
}
