using Api.DataAccess;
using System;
using System.Linq;

namespace Api.BookOperations.CreateData
{
    public class CreateBookCommand
    {
        private BookStoreDbContext _context;
        public CreateBookModel Model { get; set; }

        public CreateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Hata");
            }
            book = new Book();

            book.Title = Model.Title;
            book.PageCount=Model.PageCount;
            book.GenreId=Model.GenreId;
            book.PublishDate=Model.PublishDate;

            _context.Books.Add(book);
            _context.SaveChanges();
           
        }
    }

    public class CreateBookModel
    {

        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
