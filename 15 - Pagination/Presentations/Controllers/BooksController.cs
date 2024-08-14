using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Presentations.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations.Controllers
{

    [ServiceFilter(typeof(LogFilterAttribute))]
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



        [ServiceFilter(typeof(ValidatioFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddOneBookAsync([FromBody] BookDtoForInsertion BookDto)
        {
       
           var book = await _manager.BookService.CreateOneBookAsync(BookDto);
            return StatusCode(201, book);

        }

        [ServiceFilter(typeof(ValidatioFilterAttribute))]
        [HttpPut("id:int")]
        public async Task<IActionResult> UpdateOneBook([FromBody] BookDtoUpdate bookDto, [FromRoute(Name = "id")] int id)
        {

            await _manager.BookService.UpdateOneBookAsync(id, bookDto, true);
            return NoContent();

        }

        [ServiceFilter(typeof (ValidatioFilterAttribute))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
        {
         
                await _manager.BookService.GetOneBookByIdAsync(id, false);
                return NoContent();

        }



    }
}
