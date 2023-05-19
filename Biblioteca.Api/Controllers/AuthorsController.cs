using Biblioteca.Api.Domain;
using Biblioteca.Api.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorHandler _handler;
        public AuthorsController()
        {
            _handler = new AuthorHandler();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetByID(long id)
        {
            return _handler.GetByID(id);
        }

        [HttpPost]
        [Route("novo_autor")]
        public async Task<IActionResult> PostAuthor([FromBody] Authors author)
        {
            return _handler.PostAuthor(author);
        }

        [HttpGet]
        [Route("all_autores")]
        public async Task<IActionResult> GetAll()
        {
            return _handler.GetAll();
        }
    }
}
