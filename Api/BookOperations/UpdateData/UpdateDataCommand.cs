using Api.DataAccess;
using System;
using System.Linq;

namespace Api.BookOperations.UpdateData
{
    public class UpdateDataCommand
    {
        public int ModelId { get; set; }

        private BookStoreDbContext _context;
        public UpdateBookModel Model { get; set; }

        public UpdateDataCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var result = _context.Books.SingleOrDefault(x => x.Id == ModelId);
            if (result is null)
            {
                throw new InvalidOperationException("Güncellemede hata");
            }
            result.GenreId = Model.GenreId != default ? Model.GenreId : result.GenreId;
            result.Title = Model.Title != default ? Model.Title : result.Title;
            _context.SaveChanges();
         

        }
    }

    public class UpdateBookModel
    {

        public string Title { get; set; }
        public int GenreId { get; set; }
     
    }
}

