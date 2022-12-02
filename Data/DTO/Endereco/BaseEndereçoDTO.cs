using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class BaseEndereçoDTO
    {
        [Required]
        public string Logradouro { get; set; }
        [Required]

        public string Bairro { get; set; }


        [Range(0, 50000)]
        public int Numero { get; set; }
    }
}
