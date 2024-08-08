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
        public async Task<IActionResult> GetAllBooksAsync()
        {
 
            var bookList = await _manager.BookService.GetAllBooksAsync(false);

            return Ok(bookList);

            


        }



        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
        {
            var OneBook = await _manager.BookService.GetOneBookByIdAsync(id: id, trackChanges: true);

            Console.WriteLine(OneBook);
            if (OneBook == null)
            {
                throw new BookNotFoundException(id);
            }

            return Ok(OneBook);
        }


        [HttpPost]
        public async Task<IActionResult> AddOneBookAsync([FromBody] BookDtoForInsertion BookDto)
        {
         
            if (BookDto is null)
                return BadRequest();

           var book = await _manager.BookService.CreateOneBookAsync(BookDto);


            return StatusCode(201, book);

  

        }


        [HttpPut("id:int")]
        public async Task<IActionResult> UpdateOneBook([FromBody] BookDtoUpdate bookDto, [FromRoute(Name = "id")] int id)
        {
            if (bookDto is null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); //422

            var entity = await _manager.BookService.GetOneBookByIdAsync(id, true);
            if (entity is null)
                return NotFound();

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, true);

            return NoContent();


        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
         
                var entity = await _manager.BookService.GetOneBookByIdAsync(id, false);


                if (entity == null)
                    return NotFound();

                await _manager.BookService.GetOneBookByIdAsync(id, false);
                return NoContent();

        }



    }
}
