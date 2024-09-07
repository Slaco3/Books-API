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
		public string city { get; set; }

		public virtual IEnumerable <Book> books { get; set; }	

	}
}
