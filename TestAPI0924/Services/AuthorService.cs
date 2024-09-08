using Microsoft.EntityFrameworkCore;
using TestAPI0924.Data;
using TestAPI0924.Models;
using TestAPI0924.Models.DTO;

namespace TestAPI0924.Services
{
	public class AuthorService : IAuthorServices
	{
		private readonly DataContext _context;
		public AuthorService(DataContext context)
		{
			_context = context;
		}
		public async Task<Author> AddAuthorAsync(AuthorDTO authorDTO)
		{
			var author = new Author();
			author.FirstName = authorDTO.FirstName;
			author.LastName = authorDTO.LastName;

			_context.Authors.Add(author);
			await _context.SaveChangesAsync();
			return author;
		}

		public async Task<Author> DeleteAuthorAsync(int id)
		{
			var author = _context.Authors.SingleOrDefault(a => a.Id == id);
			if (author == null)
			{
				return null;
			}

			_context.Authors.Remove(author);

			await _context.SaveChangesAsync();

			return author;
		}

		public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
		{
			var authors = await _context.Authors.Include(a=>a.Books).ToArrayAsync();
			return authors;
		}

		public async Task<Author> GetAuthorByIdAsync(int id)
		{
			var author = await _context.Authors.Include(a => a.Books).SingleOrDefaultAsync(a=>a.Id==id);
			if (author == null)
			{
				return null ;
			}

			return author;
		}

		public async Task<Author> UpdateAuthorAsync(int id, Author author)
		{
			var updatedAuthor = await _context.Authors.SingleOrDefaultAsync(a => a.Id == id);
			if (author == null)
			{
				return null;
			}

			updatedAuthor.FirstName = author.FirstName;
			updatedAuthor.LastName = author.LastName;

			await _context.SaveChangesAsync();
			return updatedAuthor;

		}
	}
}
