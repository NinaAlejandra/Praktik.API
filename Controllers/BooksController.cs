using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Praktik.API.Models;
using Praktik.API.Services;

namespace Praktik.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        //private readonly DataService _dataService;

        public BooksController(BookService bookService/*, DataService dataService*/)
        {
            _bookService = bookService;
        //    _dataService=dataService;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CreateBook: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {
            _bookService.UpdateBook(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);

            return NoContent();
        }
    }
}
