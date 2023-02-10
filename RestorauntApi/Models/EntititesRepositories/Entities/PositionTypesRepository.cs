using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Models.EntititesRepositories.Entities
{
    public class PositionTypesRepository : BaseRepository<PositionType>, IPositionTypesRepository
    {
        public PositionTypesRepository(RestorauntDbContext context) : base(context) { }
    }
}
