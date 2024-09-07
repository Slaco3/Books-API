using TestAPI0924.Models;

namespace TestAPI0924.Services
{
	public interface IAuthorServices
	{
		Task<IEnumerable<Author>> GetAllAuthorsAsync();
		Task<Author> GetAuthorByIdAsync(int id);
		Task<Author> AddAuthorAsync(Author author);
		Task<Author> UpdateAuthorAsync(int id, Author author);
		Task<Author> DeleteAuthorAsync(int id);
	}
}
