using AutoMapper;
using FlimesApi.Data;
using FlimesApi.Data.DTO;
using FlimesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlimesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDTO cinemaDto)
        {
            var cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCinema), new { id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomeDoFilme)
        {
            var cinemas = _context.Cinemas.ToList();
            if (cinemas == null || !cinemas.Any())
                return NotFound();
            var query = from cinema in cinemas
                        where cinema.Sessoes.Any(
                            sessao => sessao.Filme.Titulo == nomeDoFilme)
                        select cinema;
            cinemas = query.ToList();
            var readDto = _mapper.Map<List<ReadCinemaDTO>>(cinemas);
            return Ok(readDto);
            //return Ok(_context.Cinemas.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema != null)
            {
                var cinemaDto = _mapper.Map<ReadCinemaDTO>(cinema);
                return Ok(cinemaDto);

            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
             return NoContent();
        }
        
        [HttpPut("{id}")]
        public IActionResult AtualizarCinema(int id, [FromBody] PutCinemaDTO cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            if (cinema == null)
                return NotFound();
            _mapper.Map(cinemaDto, cinema);
            _context.Cinemas.Update(cinema);
            _context.SaveChanges();
            return Ok(cinema);
        }
    }
}
