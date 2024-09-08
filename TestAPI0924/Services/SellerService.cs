using Microsoft.EntityFrameworkCore;
using TestAPI0924.Data;
using TestAPI0924.Models;
using TestAPI0924.Models.DTO;

namespace TestAPI0924.Services
{
	public class SellerService : ISellerService
	{
		DataContext _context;
		public SellerService(DataContext context)
		{
			_context = context;
		}
		public async Task<Seller> AddSellerAsync(SellerDTO sellerDTO)
		{
			var seller = new Seller();
			seller.FirstName = sellerDTO.FirstName;
			seller.LastName = sellerDTO.LastName;
			seller.City = sellerDTO.City;

			await _context.Sellers.AddAsync(seller);
			await _context.SaveChangesAsync();

			return seller;
		}

		public async Task<Seller> DeleteSellerAsync(int id)
		{
			var seller = await _context.Sellers.SingleOrDefaultAsync(s => s.Id == id);
			if (seller is null)
			{
				return null;
			}
			_context.Sellers.Remove(seller);
			await _context.SaveChangesAsync();
			return seller;

		}

		public async Task<IEnumerable<Seller>> GetAllSellersAsync()
		{
			var sellers = await _context.Sellers.Include(s=>s.Books).ToListAsync();
			return sellers;
		}

		public async Task<Seller> GetSellerByIdAsync(int id)
		{
			var seller = await _context.Sellers.SingleOrDefaultAsync(s => s.Id == id);
			if (seller is null)
			{
				return null;
			}
			return seller;
		}

		public async Task<Seller> UpdateSellerAsync(int id, SellerDTO sellerDTO)
		{
			var seller = await _context.Sellers.SingleOrDefaultAsync(s => s.Id == sellerDTO.Id);
			if (seller is null)
			{
				return null;
			}

			seller.FirstName = sellerDTO.FirstName;
			seller.LastName = sellerDTO.LastName;
			seller.City = sellerDTO.City;

			await _context.SaveChangesAsync();
			return seller;
		}

		public async Task<Seller> AddBookToSellerAsync(int sellerId, int bookId)
		{
			var seller = await _context.Sellers
				.Include(s => s.Books)  // Assure que les livres sont chargés
				.SingleOrDefaultAsync(s => s.Id == sellerId);

			var book = await _context.Books
				.SingleOrDefaultAsync(b => b.Id == bookId);

			if (seller == null || book == null)
			{
				return null;  // Ou une autre gestion des erreurs
			}

			if (!seller.Books.Contains(book))
			{
				seller.Books.Add(book);

				await _context.SaveChangesAsync();
			}

			return seller;
		}


	}
}
