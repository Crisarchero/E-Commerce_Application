using E_Commerce_Application.Data;
using E_Commerce_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Application.Controllers
{
	
	[Route("Menu/Review/[controller]")]
	public class ReviewController : Controller
    {
		private readonly ReviewService _reviewService;


		public ReviewController(ReviewService reviewService) =>
			_reviewService = reviewService;
		
		//Getting reviews for one product.
		public async Task<ActionResult> Get(string Id)
		{
			var reviewList = await _reviewService.GetAsync(Id);
			ViewBag.Reviews = reviewList;
			return View("Index");
		}



		//Adding a review.
		public async Task<IActionResult> Post(Review newReview)
		{
			await _reviewService.CreateAsync(newReview);

			return CreatedAtAction(nameof(Get), new { id = newReview.Id }, newReview);
		}

		//Editing a review.
		public async Task<IActionResult> Update(string id, Review updatedReview)
		{
			var review = await _reviewService.GetAsync(id);

			if (review is null)
			{
				return NotFound();
			}

			updatedReview.Id = review.Id;

			await _reviewService.UpdateAsync(id, updatedReview);

			return NoContent();
		}

		//Deleting a review.
		public async Task<IActionResult> Delete(string id)
		{
			var review = await _reviewService.GetAsync(id);

			if (review is null)
			{
				return NotFound();
			}

			await _reviewService.RemoveAsync(id);

			return NoContent();
		}
	}
}
