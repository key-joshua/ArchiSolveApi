using Common;
using Entities;

namespace Data.Repositories
{
    public class BannerZoneRepository : Repository<BannerZone>, IBannerZoneRepository, IScopedDependency
    {
        public BannerZoneRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
