using Microsoft.AspNetCore.Mvc;
using TestAPI0924.Models;
using TestAPI0924.Services;

namespace TestAPI0924.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthorServices _authorServices;

		public AuthorController(IAuthorServices authorServices)
		{
			_authorServices = authorServices;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthors()
		{
			var authors = await _authorServices.GetAllAuthorsAsync();

			return Ok(authors);	
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Author>> GetAuthorbyId(int id)
		{
			var author = await _authorServices.GetAuthorByIdAsync(id);
			if (author == null)
			{
				return BadRequest("Author not found");
			}
			return Ok(author);
		}

		[HttpPost]
		public async Task<ActionResult<Author>> AddAuthor(Author author)
		{
			var createdAuthor = await _authorServices.AddAuthorAsync(author);
			
			return createdAuthor;
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Author>> UpdateAuthor(int id, Author author)
		{
			var updatedAuthor = await _authorServices.UpdateAuthorAsync(id, author);
			if (updatedAuthor == null)
			{
				return BadRequest("Author doesn't exists");
			}
			return Ok(updatedAuthor);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Author>> DeleteAuthor(int id)
		{
			var deletedAuthor =  await _authorServices.DeleteAuthorAsync(id);
			if (deletedAuthor == null)
			{
				return BadRequest($"Unable to delete Author {id}";
			}
			return Ok(deletedAuthor);
		}
	}
}
