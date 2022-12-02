using FlimesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class ReadGerenteDTO : BaseGerenteDTO
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime HoraDaConsulta { get; set; }
        public object Cinemas { get; set; }
    }
}
