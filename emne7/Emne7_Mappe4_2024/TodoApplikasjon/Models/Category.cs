using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoApplikasjon.Models
{
    public class Category
    {
        public int Id { get; set; }    

        [Required(ErrorMessage = "Navn er påkrevd.")]
        [MinLength(3, ErrorMessage = "Navnet må være minst 3 tegn")]
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Todo> Todos { get; set; }        //Relasjon til mange todos  (En til mange)

    }
}