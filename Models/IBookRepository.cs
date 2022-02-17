using System;
using System.Linq;

namespace Indo_Burma.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
