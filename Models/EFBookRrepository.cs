using System;
using System.Linq;

namespace Indo_Burma.Models
{
    //this class will implement an instance of IBookRepository
    public class EFBookRrepository : IBookRepository
    {
        private BookstoreContext context { get; set; }

        public EFBookRrepository(BookstoreContext temp) => context = temp;

        public IQueryable<Book> Books => context.Books;
    }
}
