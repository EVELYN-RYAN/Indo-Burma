using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indo_Burma.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Indo_Burma.Infrastructure;


namespace Indo_Burma.Pages
{
    public class CartModel : PageModel
    {
        private IBookRepository repo { get; set; }
        public CartModel(IBookRepository temp)
        {
            repo = temp;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookid);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(p, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl });

        }
    }
}
