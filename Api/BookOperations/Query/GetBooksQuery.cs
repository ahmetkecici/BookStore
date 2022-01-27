using Api.Common;
using Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.BookOperations.Query
{
    public class GetBooksQuery
    {
        private BookStoreDbContext _context;

        public GetBooksQuery(BookStoreDbContext context)
        {
            _context = context;
        }
        public List<BookViewModel> Handle()
        {
            var booklist = _context.Books.OrderBy(x=>x.Id).ToList();
            List<BookViewModel> bookViewModels = new List<BookViewModel>();

            foreach (var book in booklist)
            {
                bookViewModels.Add(new BookViewModel
                {
                    Title = book.Title,
                    Genre=((GenreEnum)book.GenreId).ToString(),
                    PageCount=book.PageCount,
                    PublishDate=book.PublishDate.Date.ToString("dd/mm/y"),   
                });
            }
            return bookViewModels;
        }
    }

    public class BookViewModel
    {
      
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
