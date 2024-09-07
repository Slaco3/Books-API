using Microsoft.EntityFrameworkCore;
using TestAPI0924.Models;

namespace TestAPI0924.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Seller> Sellers { get; set; }
		public DbSet<Author> Authors { get; set; }
	

	}
}
