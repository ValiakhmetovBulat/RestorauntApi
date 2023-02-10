using RestorauntApi.Models.Entities;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Models.EntititesRepositories.Entities
{
    public class SectionsRepository : BaseRepository<Section>, ISectionsRepository
    {
        public SectionsRepository(RestorauntDbContext context) : base(context) { }
    }
}
