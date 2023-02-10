using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Models.EntititesRepositories.Entities
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(RestorauntDbContext context) : base(context) { }
    }
}
