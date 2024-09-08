using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace TestAPI0924.Models
{
	public class Seller
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string City { get; set; }

		public virtual ICollection<Book>? Books { get; set; } = new HashSet<Book>();

	}
}
