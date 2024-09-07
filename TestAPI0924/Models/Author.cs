using System.ComponentModel.DataAnnotations;

namespace TestAPI0924.Models
{
	public class Author
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; } 
		public virtual IEnumerable<Book> Books { get; set; }

	}
}
