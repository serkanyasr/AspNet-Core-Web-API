using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;


        public BooksController(IServiceManager manager)
        {

            _manager = manager;

        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
 
            var bookList = _manager.BookService.GetAllBooks(false);

            return Ok(bookList);

            


        }



        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var OneBook = _manager.BookService.GetOneBookById(id: id, trackChanges: true);

            Console.WriteLine(OneBook);
            if (OneBook == null)
            {
                throw new BookNotFoundException(id);
            }

            return Ok(OneBook);
        }


        [HttpPost]
        public IActionResult AddOneBook([FromBody] Book book)
        {
         
            if (book is null)
                return BadRequest();

            _manager.BookService.CreateOneBook(book);


            return StatusCode(201, book);

  

        }


        [HttpPut("id:int")]
        public IActionResult UpdateOneBook([FromBody] BookDtoObject bookDto, [FromRoute(Name = "id")] int id)
        {
            if (bookDto is null)
                return BadRequest();

            var entity = _manager.BookService.GetOneBookById(id, true);
            if (entity is null)
                return NotFound();

            _manager.BookService.UpdateOneBook(id, bookDto, true);

            return NoContent();


        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
         
                var entity = _manager.BookService.GetOneBookById(id, false);


                if (entity == null)
                    return NotFound();

                _manager.BookService.DeleteOneBook(id, false);
                return NoContent();

        }



    }
}
