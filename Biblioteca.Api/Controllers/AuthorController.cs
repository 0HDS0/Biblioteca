using Biblioteca.Api.Domain;
using Biblioteca.Api.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        AuthorHandler _handler;
        public AuthorController()
        {
            _handler = new AuthorHandler();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(long id)
        {
            Author? autor = _handler.GetByID(id);

            if (autor == null) { NotFound("Autor não encontrado!"); }

            return Ok(autor);
        }

        [HttpPost]
        [Route("novo")]
        public async Task<IActionResult> PostAuthor([FromBody] Author author)
        {
            if (_handler.PostAuthor(author))
                return Created($"api/Author/{author.ID}", author);

            return Conflict("Autor já está cadastrado!");
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeteleByID(long id)
        {
            if (_handler.DeleteByID(id))
                return Ok();
            return NotFound("Autor não encontrado");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] Author author)
        {
            if (_handler.Put(author))
                return Ok(author);
            return NotFound("Autor não encontrado!");
        }  

    }
}
