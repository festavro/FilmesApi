using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlimesApi.Models
{
    public class Endereco
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Logradouro { get; set; }
        [Required]
        
        public string Bairro { get; set; }


        [Range(0, 50000)]
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
