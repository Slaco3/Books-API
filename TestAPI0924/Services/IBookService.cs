using TestAPI0924.Models;
using TestAPI0924.Models.DTO;

namespace TestAPI0924.Services
{
	public interface IBookService
	{
		Task<IEnumerable<Book>> GetAllBooksAsync();
		Task<Book> GetBookByIdAsync(int id);
		Task<Book> AddBookAsync(BookDTO bookDTO);
		Task<Book> UpdateBookAsync(int id, Book book);
		Task<Book> DeleteBookAsync(int id);
	}
}
