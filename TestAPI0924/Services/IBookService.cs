using TestAPI0924.Models;

namespace TestAPI0924.Services
{
	public interface IBookService
	{
		Task<IEnumerable<Book>> GetAllBooksAsync();
		Task<Book> GetBookByIdAsync(int id);
		Task<Book> AddBookAsync(Book book);
		Task<Book> UpdateBookAsync(int id, Book book);
		Task<Book> DeleteBookAsync(int id);
	}
}
