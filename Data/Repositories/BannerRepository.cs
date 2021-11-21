using Common;
using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public class BannerRepository : Repository<Banner>, IBannerRepository, IScopedDependency
    {
        public BannerRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Banner> GetLastBanners(int top, bool? isPublished, CancellationToken cancellationToken)
        {
            if (isPublished.HasValue)
            {
                return Table.Where(p => p.IsPublished == isPublished).Take(top).OrderByDescending(x => x.Id);
            }
            else
            {
                return Table.Take(top).OrderByDescending(x => x.Id);
            }
        }
    }
}
