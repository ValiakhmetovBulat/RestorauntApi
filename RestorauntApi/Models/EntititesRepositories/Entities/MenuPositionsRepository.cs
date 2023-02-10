using RestorauntApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using RestorauntApi.Models.EntititesRepositories;
using RestorauntApi.Models.EntititesRepositories.Interfaces;

namespace RestorauntApi.Models.EntititesRepositories.Entities
{
    public class MenuPositionsRepository : BaseRepository<MenuPosition>, IMenuPositionsRepository
    {
        public MenuPositionsRepository(RestorauntDbContext context) : base(context) { }
    }
}
