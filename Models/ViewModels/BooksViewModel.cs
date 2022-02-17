using System.Linq;

namespace Indo_Burma.Models.ViewModels
{
    //combines the models together into a single model so we can bring everything to the view in a single model
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}