using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlimesApi.Models
{
    public class Filme
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "Campo Diretor é obrigatório")]
        
        public string Diretor { get; set; }

        [StringLength(30)]
        public string Genero { get; set; }

        [Range(0, 5000, ErrorMessage = "Duracao deve ser entre 0 e 5000")]
        public int Duracao { get; set; }
        [Range(0, 18, ErrorMessage = "Classificação etaria deve ser entre 0 e 18") ]
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
