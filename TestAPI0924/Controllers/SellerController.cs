using Microsoft.AspNetCore.Mvc;
using TestAPI0924.Models.DTO;
using TestAPI0924.Models;
using TestAPI0924.Services;
using Microsoft.EntityFrameworkCore;

namespace TestAPI0924.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SellerController : ControllerBase
	{
		private readonly ISellerService _sellerService;

		public SellerController(ISellerService sellerService)
		{
			_sellerService = sellerService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Seller>>> GetAllSellers()
		{
			var sellers = await _sellerService.GetAllSellersAsync();

			return Ok(sellers);
		}


		[HttpGet("{id}")]
		public async Task<ActionResult<Seller>> GetSellerById(int id)
		{
			var seller = await _sellerService.GetSellerByIdAsync(id);
			if (seller == null)
			{
				return BadRequest("Seller not found");
			}
			return Ok(seller);
		}

		[HttpPost]
		public async Task<ActionResult<Seller>> AddSeller(SellerDTO sellerDTO)
		{
			var createdSeller = await _sellerService.AddSellerAsync(sellerDTO);

			return createdSeller;
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Seller>> UpdateSeller(int id, SellerDTO sellerDTO)
		{
			if (id != sellerDTO.Id)
			{
				return BadRequest("Conflict between IDs");
			}

			var updatedSeller = await _sellerService.UpdateSellerAsync(id, sellerDTO);

			if (updatedSeller == null)
			{
				return BadRequest("Seller doesn't exists");
			}
			return Ok(updatedSeller);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Seller>> DeleteSeller(int id)
		{
			var deletedSeller = await _sellerService.DeleteSellerAsync(id);
			if (deletedSeller == null)
			{
				return BadRequest($"Unable to delete Seller {id}");
			}
			return Ok(deletedSeller);
		}



		[HttpPost("{sellerId}/books/{bookId}")]
		public async Task<ActionResult> AddBookToSeller(int sellerId, int bookId)
		{
			var seller = await _sellerService.AddBookToSellerAsync(bookId, sellerId);
			if (seller == null)
			{
				return BadRequest($"Impossible d'ajouter le livre ID {bookId} au seller ID {sellerId}");
			}
			return Ok(seller);
		}

	}
}

