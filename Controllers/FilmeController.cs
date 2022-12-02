using AutoMapper;
using FlimesApi.Data;
using FlimesApi.Data.DTO;
using FlimesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlimesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            var filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFilme), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
                filmes = _context.Filmes.ToList();
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();

            }
            if (filmes != null)
            {
                var readDto = _mapper.Map<List<ReadFilmeDTO>>(filmes);
                return Ok(filmes);
            }

            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);
                return Ok(filmeDto);

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return NotFound();
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
             return NoContent();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] PutFilmeDTO filmeDto)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.Filmes.Update(filme);
            _context.SaveChanges();
            return Ok(filme);
        }
    }
}
