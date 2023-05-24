using Biblioteca.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Handlers
{
    public class AuthorHandler
    {
        public static List<Author> authors = new List<Author>();
        public Author? GetByID(long id)
        {
            return authors.Where(X=>X.ID == id).FirstOrDefault();
        }
        public bool PostAuthor(Author author)
        {
            Author conflict = authors.Where(X => X.ID == author.ID).FirstOrDefault();

            if (conflict != null)
                return false;
            
            authors.Add(author);
            return true;
        }

        public bool DeleteByID(long id)
        {
            return authors.RemoveAll(X => X.ID == id) > 0;
        }

        public bool Put(Author author)
        {
            Author authorExist = authors.Where(X => X.ID == author.ID).FirstOrDefault();
            if (authorExist == null)
                return false;

            authors.Where(X => X.ID == author.ID).ToList()
                .ForEach(X => 
                { 
                    //colocar bibliografia depis caso
                    X.Name = author.Name;
                    X.ArtisticName = author.ArtisticName;
                });
            return true;
        }
    }
}
