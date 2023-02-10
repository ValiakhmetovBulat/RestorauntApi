using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        IReviewRepository _db;

        public ReviewController(IReviewRepository db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets all the reviews
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        public async Task<IEnumerable<Review>> Get() => await _db.GetAll();

        /// <summary>
        /// Creates new review
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Review>> Post(Review review)
        {
            if (review == null)
                return BadRequest("Object was null");

            return await _db.Create(review);
        }
    }
}
