namespace TestAPI0924.Models.DTO
{
	public class BookDTO
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateOnly Created { get; set; }
		public string Categorie { get; set; }
		public int AuthorId { get; set; }
	}
}
