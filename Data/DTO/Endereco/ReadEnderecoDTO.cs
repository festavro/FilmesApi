using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class ReadEnderecoDTO : BaseEndereçoDTO
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
