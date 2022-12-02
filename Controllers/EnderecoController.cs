using AutoMapper;
using FlimesApi.Data;
using FlimesApi.Data.DTO;
using FlimesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlimesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDTO EnderecoDto)
        {
            var Endereco = _mapper.Map<Endereco>(EnderecoDto);
            _context.Enderecos.Add(Endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarEndereco), new { id = Endereco.Id }, Endereco);
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            return Ok(_context.Enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarEndereco(int id)
        {
            var Endereco = _context.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (Endereco != null)
            {
                var EnderecoDto = _mapper.Map<ReadEnderecoDTO>(Endereco);
                return Ok(EnderecoDto);

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            var Endereco = _context.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (Endereco == null)
                return NotFound();
            _context.Enderecos.Remove(Endereco);
            _context.SaveChanges();
             return NoContent();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, [FromBody] PutEnderecoDTO EnderecoDto)
        {
            var Endereco = _context.Enderecos.FirstOrDefault(Endereco => Endereco.Id == id);
            if (Endereco == null)
                return NotFound();
            _mapper.Map(EnderecoDto, Endereco);
            _context.Enderecos.Update(Endereco);
            _context.SaveChanges();
            return Ok(Endereco);
        }
    }
}
