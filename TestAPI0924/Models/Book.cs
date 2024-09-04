namespace TestAPI0924.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public string Categorie { get; set; }

	}
}
