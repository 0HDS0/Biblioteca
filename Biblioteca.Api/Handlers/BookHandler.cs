using Biblioteca.Api.Domain;

namespace Biblioteca.Api.Handlers
{
    public class BookHandler
    {
        public static List<Book> _books= new List<Book>();

        public Book? GetById(long id)
        {
            return _books.Where(X => X.ID == id).FirstOrDefault();
        }
    }
}
