using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAPI0924.Models
{
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public DateOnly Created { get; set; } = DateOnly.FromDateTime(DateTime.Now);

		[Required]
		public string Categorie { get; set; }

		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }

		public Author Author { get; set; }	

		public virtual IEnumerable<Seller> Sellers { get; set; }
	}
}


