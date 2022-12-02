using AutoMapper;
using FlimesApi.Data;
using FlimesApi.Data.DTO;
using FlimesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlimesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] CreateGerenteDTO GerenteDto)
        {
            var Gerente = _mapper.Map<Gerente>(GerenteDto);
            _context.Gerentes.Add(Gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarGerente), new { id = Gerente.Id }, Gerente);
        }

        [HttpGet]
        public IActionResult RecuperarGerentes()
        {
            return Ok(_context.Gerentes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarGerente(int id)
        {
            var Gerente = _context.Gerentes.FirstOrDefault(Gerente => Gerente.Id == id);
            if (Gerente != null)
            {
                var GerenteDto = _mapper.Map<ReadGerenteDTO>(Gerente);
                return Ok(GerenteDto);

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            var Gerente = _context.Gerentes.FirstOrDefault(Gerente => Gerente.Id == id);
            if (Gerente == null)
                return NotFound();
            _context.Gerentes.Remove(Gerente);
            _context.SaveChanges();
             return NoContent();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarGerente(int id, [FromBody] PutGerenteDTO GerenteDto)
        {
            var Gerente = _context.Gerentes.FirstOrDefault(Gerente => Gerente.Id == id);
            if (Gerente == null)
                return NotFound();
            _mapper.Map(GerenteDto, Gerente);
            _context.Gerentes.Update(Gerente);
            _context.SaveChanges();
            return Ok(Gerente);
        }
    }
}
