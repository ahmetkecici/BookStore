using Api.Common;
using Api.DataAccess;
using System.Linq;

namespace Api.BookOperations.Query
{
    public class GetBookByIdQuery
    {
        private BookStoreDbContext _context;
        public int ModelId { get; set; }


        public GetBookByIdQuery(BookStoreDbContext context)
        {
            _context = context;
        }
        public BookViewModel Handle()
        {
            var book = _context.Books.SingleOrDefault(x=>x.Id==ModelId);
           BookViewModel viewModel = new BookViewModel
           {
               Title = book.Title,
               Genre = ((GenreEnum)book.GenreId).ToString(),
               PageCount = book.PageCount,
               PublishDate = book.PublishDate.Date.ToString("dd/mm/y"),
           };
            return viewModel;
        }
    }
}

