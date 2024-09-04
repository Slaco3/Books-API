using Microsoft.EntityFrameworkCore;
using TestAPI0924.Data;
using TestAPI0924.Models;

namespace TestAPI0924.Services
{
	public class BookService : IBookService
	{
		private readonly DataContext _context;

		public BookService(DataContext context)
		{
			_context = context;
		}

		public async Task<Book> AddBookAsync(Book book)
		{
			await _context.Books.AddAsync(book);
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task<Book> DeleteBookAsync(int id)
		{
			var book = await _context.Books.SingleOrDefaultAsync(b=>b.Id == id);
			if (book is null)
			{
				return null;
			}
			_context.Books.Remove(book);
			await _context.SaveChangesAsync();
			return book;
		}

		public async Task<IEnumerable<Book>> GetAllBooksAsync()
		{
			var books = await _context.Books.ToListAsync();
			return books;
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			var book = await _context.Books.SingleOrDefaultAsync(book=> book.Id == id);
			return book;
		}

		public async Task<Book> UpdateBookAsync(int id, Book book)
		{
			var updateBook = await _context.Books.SingleOrDefaultAsync(b=>b.Id==id);
			if (updateBook is null)
			{
				return null;
			}

			updateBook.Author = book.Author;
			updateBook.Title = book.Title;
			updateBook.Description = book.Description;
			updateBook.Categorie = book.Categorie;
			updateBook.Created = book.Created;

			await _context.SaveChangesAsync();
			return updateBook;
		}
	}
}
