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

			await _context.AddAsync(seller);
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

		public  async Task<IEnumerable<Seller>> GetAllSellersAsync()
		{
			var sellers = await _context.Sellers.ToListAsync();
			return sellers;
		}

		public  async Task<Seller> GetSellerByIdAsync(int id)
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
	}
}
