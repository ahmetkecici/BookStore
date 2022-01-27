using Api.DataAccess;
using System;
using System.Linq;

namespace Api.BookOperations.DeleteData
{
    public class DeleteBookCommand
    {
        public int ModelId { get; set; }

        private BookStoreDbContext _context;
 
        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var result = _context.Books.SingleOrDefault(x => x.Id == ModelId);
            if (result is null)
            {
                throw new InvalidOperationException("Silerken Hata");
            }
            _context.Books.Remove(result);
            _context.SaveChanges();
           


        }
    }
}
