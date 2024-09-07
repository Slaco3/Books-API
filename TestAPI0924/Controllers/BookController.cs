using Microsoft.AspNetCore.Mvc;
using TestAPI0924.Models;
using TestAPI0924.Services;

namespace TestAPI0924.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{

		private readonly IBookService _bookService;

		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
		{
			var books = await _bookService.GetAllBooksAsync();

			return Ok(books);

		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Book>> GetBookByid(int id)
		{
			var book = await _bookService.GetBookByIdAsync(id);
			if (book is null)
			{
				return BadRequest("Book not found");
			}
			return Ok(book);
		}

		[HttpPost]
		public async Task<ActionResult<Book>> AddBook(Book book)
		{
			var createdBook = await _bookService.AddBookAsync(book);

			if (createdBook is null)
			{
				return BadRequest("Author not found or book could not be created.");
			}
			return Ok(createdBook);
		}


		[HttpPut("{id}")]
		public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
		{
			var updatedBook = await _bookService.UpdateBookAsync(id, book);
			if (updatedBook is null)
			{
				return BadRequest("Book doesn't exists");
			}
			return Ok(updatedBook);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Book>> DeleteBook(int id)
		{
			var deletedBook = await _bookService.DeleteBookAsync(id);
			if (deletedBook is null)
			{
				return BadRequest($"Unable to delete book {id}");
			}
			return Ok(deletedBook);

		}
	}
}