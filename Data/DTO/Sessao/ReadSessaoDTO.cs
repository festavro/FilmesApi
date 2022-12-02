using FlimesApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FlimesApi.Data.DTO
{
    public class ReadSessaoDTO : BaseSessaoDTO
    {
        public Cinema Cinema { get; set; }
        public Filme Filme{ get; set; }

    }
}
