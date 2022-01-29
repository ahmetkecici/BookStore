using Api.BookOperations.CreateData;
using Api.BookOperations.DeleteData;
using Api.BookOperations.Query;
using Api.BookOperations.UpdateData;
using Api.DataAccess;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //  private static List<Book> _books;
        private BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public BooksController(BookStoreDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //var data = _dbContext.Books.ToList();
            //return data;
            GetBooksQuery query=new GetBooksQuery(_dbContext);
            var data = query.Handle();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var result = _dbContext.Books.FirstOrDefault(x => x.Id == id);
            return result ;
        }
        //[HttpGet]
        //public Book GetById2([FromQuery] string id)
        //{
        //    var result = _books.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
        //    return result;
        //}

        [HttpPost]
        public IActionResult Add([FromBody] CreateBookModel book)
        {
            //var result = _dbContext.Books.SingleOrDefault(x => x.Title == book.Title);
            //if (result is not null)
            //{
            //    return BadRequest();
            //}
            //_dbContext.Books.Add(book);
            //_dbContext.SaveChanges();
            //return Ok();
            var command = new CreateBookCommand(_dbContext,_mapper);
            

            try
            {
                command.Model = book;
                CreateBookValidator validator=new CreateBookValidator();
                 validator.ValidateAndThrow(command);
              
                command.Handle();
               
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
            return Ok(command);
            
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] UpdateBookModel book)
        {
            var command = new UpdateDataCommand(_dbContext);


            try
            {
                command.ModelId=id;
                command.Model = book;
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {

            var command = new DeleteBookCommand(_dbContext);


            try
            {
                command.ModelId = id;
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok("Başarılı");
        }
    }
}
