using System;
using System.Linq;
using Indo_Burma.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indo_Burma.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private IBookRepository repo { get; set; }

        public CategoryViewComponent (IBookRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {                               // need the endpoints together to do this RouteData
            ViewBag.SelectedCategory = RouteData?.Values["bookCat"];
            var cat = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);
            return View(cat);
        }
    }
}
