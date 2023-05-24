using Biblioteca.Api.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Biblioteca.Api.Handlers
{
    public class GenreHandler
    {

        public static List<Genre> genres = new List<Genre>();
         public Genre? GetID(long id)
         {
            return genres.Where(X => X.ID == id).FirstOrDefault();
         }
        public bool PostGenre(Genre genre)
        {
            Genre conflict = genres.Where(X=>X.ID == genre.ID).FirstOrDefault();

            if (conflict !=null)
                return false;
            
            genres.Add(genre);
            return true;
        }

        //Em processo
        public bool DeleteByID(long id)
        {
            return genres.RemoveAll(X => X.ID == id) > 0;
            
        }

        public bool Put(Genre genre)
        {
            Genre genreExist = genres.Where(X => X.ID == genre.ID).FirstOrDefault();
            if (genreExist == null)
                return false;

            genres.Where(X => X.ID == genre.ID).ToList()
                .ForEach(X =>
                {
                    X.Classification = genre.Classification;
                    X.Description = genre.Description;
                });
            return true;
        }

    }
}
