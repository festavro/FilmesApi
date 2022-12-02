using AutoMapper;
using FlimesApi.Data;
using FlimesApi.Data.DTO;
using FlimesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlimesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public SessaoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDTO SessaoDto)
        {
            var Sessao = _mapper.Map<Sessao>(SessaoDto);
            _context.Sessoes.Add(Sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarSessao), new { id = Sessao.Id }, Sessao);
        }

        [HttpGet]
        public IActionResult RecuperarSessoes()
        {
            return Ok(_context.Sessoes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarSessao(int id)
        {
            var Sessao = _context.Sessoes.FirstOrDefault(Sessao => Sessao.Id == id);
            if (Sessao != null)
            {
                var SessaoDto = _mapper.Map<ReadSessaoDTO>(Sessao);
                return Ok(SessaoDto);

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            var Sessao = _context.Sessoes.FirstOrDefault(Sessao => Sessao.Id == id);
            if (Sessao == null)
                return NotFound();
            _context.Sessoes.Remove(Sessao);
            _context.SaveChanges();
             return NoContent();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarSessao(int id, [FromBody] PutSessaoDTO SessaoDto)
        {
            var Sessao = _context.Sessoes.FirstOrDefault(Sessao => Sessao.Id == id);
            if (Sessao == null)
                return NotFound();
            _mapper.Map(SessaoDto, Sessao);
            _context.Sessoes.Update(Sessao);
            _context.SaveChanges();
            return Ok(Sessao);
        }
    }
}
