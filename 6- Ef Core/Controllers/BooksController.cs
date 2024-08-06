using bsStoreApp.Models;
using bsStoreApp.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace bsStoreApp.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContex _context;

        public BooksController(RepositoryContex context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var bookList = _context.Books.ToList();

                return Ok(bookList);

            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }

        }

        
        
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name ="id")] int id)
        {
            try
            {
                var OneBook = _context.Books.Where(x => x.Id.Equals(id)).SingleOrDefault();

                Console.WriteLine(OneBook);
                if (OneBook == null)
                {
                    return NotFound();
                }


                return Ok(OneBook);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name ="id")] int id)
        {
            try
            {
                var entity = _context.Books
                    .Where(x => x.Id.Equals(id)).SingleOrDefault();

                if (entity == null)
                    return NotFound();

                _context.Books.Remove(entity);
                _context.SaveChanges();
                return NoContent();

            }
            catch (Exception  ex)
            {

                throw new Exception(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult AddOneBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                _context.Books.Add(book);
                _context.SaveChanges();

                return StatusCode(201,book);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        [HttpPut]
        public IActionResult UpdateOneBook([FromBody] Book book)
        {
            if (book is null)
                return BadRequest();

            var enttiy = _context.Books.FirstOrDefault(x => x.Id == book.Id);
            if (enttiy is null)
                return NotFound();

            enttiy.Title = book.Title;
            enttiy.Price = book.Price;
            _context.SaveChanges();

            return NoContent();
            

        }
    }
}
