using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.DataAccess
{
    public class DataSeed
    {
        public static void Initilaze(IServiceProvider serviceProvider)
        {
            using (var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {

                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(
                      new Book {// Id = 1,
                          GenreId = 1, Title = "Olasılıksız", PageCount = 255, PublishDate = new DateTime(2012, 06, 25) },

                new Book { //Id = 2,
                    GenreId = 2, Title = "Doctor Who", PageCount = 425, PublishDate = new DateTime(2013, 06, 25) },
                new Book { //Id = 3,
                    GenreId = 4, Title = "Sherlock Holmes", PageCount = 312, PublishDate = new DateTime(2014, 05, 15) },
                new Book { //Id = 4,
                    GenreId = 3, Title = "Tesla", PageCount = 124, PublishDate = new DateTime(2012, 06, 25) },
                new Book {// Id = 5,
                    GenreId = 5, Title = "Sistem mühendisliği", PageCount = 512, PublishDate = new DateTime(2012, 06, 25) }
                    );
                context.SaveChanges();
            }
        }

      
    }
}
