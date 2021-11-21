using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public interface IBannerRepository : IRepository<Banner>
    {
        IQueryable<Banner> GetLastBanners(int top, bool? isPublished, CancellationToken cancellationToken);
    }
}