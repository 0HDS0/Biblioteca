using Biblioteca.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Biblioteca.Api.Handlers
{
    public class GenreHandler
    {

        public static List<Genre> genres = new List<Genre>();
         public IActionResult GetId(long id)
         {

            //   Genre genre = genres.Where(X => X.ID == id).FirstOrDefault();
            //   return genre;
            Genre genre = genres.Where(X => X.ID == id).FirstOrDefault();
            if (genre == null)
            {
                return new NotFoundObjectResult("Este Genêro não existe!");
            }
            return new OkObjectResult(genre);
         }
        public IActionResult PostGenre(Genre genre)
        {
            Genre conflict = genres.Where(X=>X.ID == genre.ID).FirstOrDefault();
            if (conflict !=null)
            {
                return new ConflictObjectResult("Este genêro já está cadastado!");
            }
            genres.Add(genre);
            return new CreatedResult($"", "Genêro Cadastrado com sucesso!");
        }

        //Em processo
        public IActionResult Delete(long id)
        {
            Genre genre = genres.Where(X => X.ID == id).FirstOrDefault();
            return new OkObjectResult($"O genero de id:{id} Foi deletado comsucesso!!");
        }

        public IActionResult Put(string nome)
        { return new ; }

        public IActionResult GetAll()
        {
            return new OkObjectResult(genres);
        }
    }
}
