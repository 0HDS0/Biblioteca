using Biblioteca.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Handlers
{
    public class AuthorHandler
    {
        List<Authors> authors = new List<Authors>();
        public IActionResult GetByID(long id)
        {
            Authors author = authors.Where(X=>X.ID == id).FirstOrDefault();
            if (author == null)
            {
                return new NotFoundObjectResult("Esse Autor Não Existe!");
            }
            return new OkObjectResult(author);
        }
        public IActionResult PostAuthor(Authors author)
        {
            Authors conflict = authors.Where(X => X.ID == author.ID).FirstOrDefault();
            if (conflict != null)
            {
                return new ConflictObjectResult(conflict);
            }

            authors.Add(author);
            return new CreatedResult("","Autor cadastrado com sucesso!");
        }
        public IActionResult GetAll()
        {
            return new OkObjectResult(authors);
        }
    }
}
