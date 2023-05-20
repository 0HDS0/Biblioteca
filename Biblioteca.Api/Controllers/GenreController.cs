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
            return _handler.GetId(id);
        }

        [HttpPost]
        [Route("novo")]
        public async Task<IActionResult> PostGenre([FromBody]Genre genre)
        {
            return _handler.PostGenre(genre);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeteleByID(long id)
        {
            return _handler.Delete(id);
        }

        [HttpPut]
        [Route("pessoa/atualiza/{nome}")]

        [HttpGet]
        [Route("all_generos")]
        public async Task<IActionResult> GetAll()
        {
            return _handler.GetAll();
        } 

    }
}
