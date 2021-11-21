using Common;
using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public class PageRepository : Repository<Page>, IPageRepository, IScopedDependency
    {
        public PageRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Page> GetPagesByParentId(int parentId, bool? isPublished, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.IsPublished == isPublished && p.ParentId == parentId);
        }

    }
}
