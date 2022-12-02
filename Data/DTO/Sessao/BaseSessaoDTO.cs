using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class BaseSessaoDTO
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
