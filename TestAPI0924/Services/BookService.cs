using Microsoft.EntityFrameworkCore;
using TestAPI0924.Data;
using TestAPI0924.Models;
using TestAPI0924.Models.DTO;

namespace TestAPI0924.Services
{
	public class BookService : IBookService
	{
		private readonly DataContext _context;

		public BookService(DataContext context)
		{
			_context = context;
		}

		public async Task<Book> AddBookAsync(BookDTO bookDTO)
		{	

			var author = _context.Authors.SingleOrDefault(a=>a.Id == bookDTO.AuthorId);

			if (author == null)
			{
				return null;
			}

			var book = new Book();
			book.Author = author;
			//book.AuthorId = author.Id;
			book.Title = bookDTO.Title;
			book.Description = bookDTO.Description;
			book.Categorie = bookDTO.Categorie;
			book.Created = bookDTO.Created;

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
			var books = await _context.Books.Include(b=>b.Author).ToListAsync();
			return books;
		}

		public async Task<Book> GetBookByIdAsync(int id)
		{
			var book = await _context.Books.Include(b=>b.Author).SingleOrDefaultAsync(book=> book.Id == id);
			return book;
		}

		public async Task<Book> UpdateBookAsync(int id, Book book)
		{
			var updateBook = await _context.Books.SingleOrDefaultAsync(b=>b.Id==id);
			if (updateBook is null)
			{
				return null;
			}

			var udpateAuthor = await _context.Authors.SingleOrDefaultAsync(a=>a.Id==book.AuthorId);
			if (udpateAuthor is null)
			{
				return null;
			}

			updateBook.Author = udpateAuthor;
			updateBook.Title = book.Title;
			updateBook.Description = book.Description;
			updateBook.Categorie = book.Categorie;
			updateBook.Created = book.Created;

			await _context.SaveChangesAsync();
			return updateBook;
		}
	}
}
