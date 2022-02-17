using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Indo_Burma.Models;
using Indo_Burma.Models.ViewModels;

namespace Indo_Burma.Controllers
{
    public class HomeController : Controller
    {
        //Build an instance of a repository that we built
        private IBookRepository repo;
        //Contructor --> no longer accessing context directly
        public HomeController(IBookRepository temp) => repo = temp;

        public IActionResult Index(int pageNum = 1)
        {
            var pageSize = 10;

            var x = new BooksViewModel
            {
                //Here the books from the repository are loaded
                Books = repo.Books
            .OrderBy(b => b.BookId)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize),
                //Here the page information is loaded
                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
        return View(x);

    }

    }
}
