using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class CreateCinemaDTO : BaseSessaoDTO
    {
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}
