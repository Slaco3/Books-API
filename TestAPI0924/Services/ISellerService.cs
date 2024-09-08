using System.Collections.Generic;
using TestAPI0924.Models;
using TestAPI0924.Models.DTO;

namespace TestAPI0924.Services
{
	public interface ISellerService
	{
		public Task<IEnumerable<Seller>> GetAllSellersAsync();
		public Task<Seller> GetSellerByIdAsync(int id);
		public Task<Seller> DeleteSellerAsync(int id);
		public Task<Seller> AddSellerAsync(SellerDTO sellerDTO);
		public Task<Seller> UpdateSellerAsync(int id, SellerDTO sellerDTO);
		public Task<Seller> AddBookToSellerAsync(int sellerId, int bookId);
	}
}
