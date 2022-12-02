using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class BaseCinemaDTO
    {

        [Required]
        public string Nome { get; set; }
    }
}
