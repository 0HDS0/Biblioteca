using Biblioteca.Api.Domain;
using Biblioteca.Api.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private GenreHandler _handler;

       public GenreController()
        {
            _handler = new GenreHandler();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(long id)
        {
            Genre? genre = _handler.GetID(id);

            if (genre == null) { NotFound("Genero não encontrado!"); }

            return Ok(genre);
        }

        [HttpPost]
        [Route("novo")]
        public async Task<IActionResult> PostGenre([FromBody]Genre genre)
        {

            if (_handler.PostGenre(genre))
                return Created($"api/Genre/{genre.ID}", genre);

            return Conflict("Genero já está cadastrado!");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeteleByID(long id)
        {
            if (_handler.DeleteByID(id))
                return Ok();
            return NotFound("Genero não encontrado");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] Genre genre)
        {
            if (_handler.Put(genre))
                return Ok(genre);
            return NotFound("Autor não encontrado!");
        }

    }
}
