using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class ReadCinemaDTO : BaseSessaoDTO
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
