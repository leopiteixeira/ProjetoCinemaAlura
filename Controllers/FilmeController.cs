using ProjetoAlura.Models;
using Microsoft.AspNetCore.Mvc;
using ProjetoAlura.Data;
using ProjetoAlura.Data.Dtos;
using AutoMapper;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.JsonPatch;

namespace ProjetoAlura.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(pesquisarPorId), new { id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<ReadFilmeDto> lerFilme([FromQuery] int skip = 0, [FromQuery] int take = 10, [FromQuery] string ?nomeCine = null){
            if(nomeCine == null){
                return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).ToList());
            }
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take)
                                                                .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCine)).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult pesquisarPorId(int id){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult atualizarFilme(int id, [FromBody] UpdateFilmeDto filmeDto){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult atualizarFilmePatch(int id, JsonPatchDocument<UpdateFilmeDto> patch){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();

            UpdateFilmeDto filmePAtualizar = _mapper.Map<UpdateFilmeDto>(filme);

            patch.ApplyTo(filmePAtualizar, ModelState);

            if(!TryValidateModel(filmePAtualizar)){
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmePAtualizar, filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deletaFilme(int id){
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null) return NotFound();

            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}