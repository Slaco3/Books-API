using TestAPI0924.Models;
using TestAPI0924.Models.DTO;

namespace TestAPI0924.Services
{
	public interface IAuthorServices
	{
		Task<IEnumerable<Author>> GetAllAuthorsAsync();
		Task<Author> GetAuthorByIdAsync(int id);
		Task<Author> AddAuthorAsync(AuthorDTO authorDTO);
		Task<Author> UpdateAuthorAsync(int id, Author author);
		Task<Author> DeleteAuthorAsync(int id);
	}
}
