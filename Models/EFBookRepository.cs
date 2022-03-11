using System;
using System.Linq;

namespace Indo_Burma.Models
{
    //this class will implement an instance of IBookRepository
    public class EFBookRepository : IBookRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookRepository(BookstoreContext temp) => context = temp;

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteBook(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
