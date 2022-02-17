using System;
namespace Indo_Burma.Models.ViewModels
{
    //Keeps track of all information on the page from a post
    public class PageInfo
    {
        public int TotalNumBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int CurrentPage { get; set; }

        // This will be calculated
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
