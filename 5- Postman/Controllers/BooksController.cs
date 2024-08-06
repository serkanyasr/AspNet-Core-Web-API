using bookApp.Data;
using bookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookApp.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Get all books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        // Get a single book by ID
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = ApplicationContext.Books.Where(x => x.ID == id).SingleOrDefault();
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // Create a new book
        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();
                }
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update an existing book by ID
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            var existingBook = ApplicationContext.Books.Find(x => x.ID.Equals(id));
            if (existingBook is null)
            {
                return NotFound(); // 404
            }
            // Check if the ID in the route matches the ID in the body
            if (id != book.ID)
            {
                return BadRequest(); // 400
            }
            ApplicationContext.Books.Remove(existingBook);
            book.ID = existingBook.ID;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        // Delete all books
        [HttpDelete]
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }

        // Delete a single book by ID
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext.Books.Find(x => x.ID.Equals(id));
            if (entity is null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    Message = $"Book with ID:{id} could not be found."
                });
            }
            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }

        // Partially update a book by ID
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            var entity = ApplicationContext.Books.Find(x => x.ID.Equals(id));
            if (entity is null)
            {
                return NotFound();
            }
            bookPatch.ApplyTo(entity);
            return NoContent();
        }
    }
}
