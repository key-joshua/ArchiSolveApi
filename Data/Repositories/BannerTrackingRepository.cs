using Common;
using Entities;

namespace Data.Repositories
{
    public class BannerTrackingRepository : Repository<BannerTracking>, IBannerTrackingRepository, IScopedDependency
    {
        public BannerTrackingRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
