using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class BaseGerenteDTO
    {

        [Required]
        public string Nome { get; set; }
    }
}
