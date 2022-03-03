using System.Collections.Generic;
using System.Linq;
namespace Indo_Burma.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();
        public virtual void AddItem(Book bk, int qty)
        {
            //Grab the book info from the the book that was requested upon "add to cart"
            CartLineItem line = Items
                .Where(b => b.Book.BookId == bk.BookId)
                .FirstOrDefault();

            if (line == null) // If there is nothing currently in the cart  the add this.
            {
                Items.Add(new CartLineItem
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else // Else if that book has already been place in the cart before.. append to QTY.
            {
                line.Quantity += qty;
            }
        }
        //Calculate and returns the total of entire cart.
        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Quantity * x.Book.Price);
            return (sum);
        }
        // Create the methods that will support the Sessionbasket class
        public virtual void RemoveItem(Book bk)
        {
            Items.RemoveAll(x => x.Book.BookId == bk.BookId);


        }
        public virtual void ClearCart() => Items.Clear();
    }
    public class CartLineItem //small class properties special to the cart page.
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
