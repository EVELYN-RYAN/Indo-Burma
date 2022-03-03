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
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        private IBookRepository repo { get; set; }
        public CartModel(IBookRepository temp, Cart c)
        {
            repo = temp;
            cart = c;

        }
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int bookid, string returnUrl)
        {
            Book p = repo.Books.FirstOrDefault(x => x.BookId == bookid);
            cart.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        // This is the method called and constructed by naming in the deletion form
        public IActionResult OnPostRemove(int bookid,string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookid).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
