using Common;
using Entities;
using System.Linq;
using System.Threading;


namespace Data.Repositories
{
    public class ContentRepository : Repository<Content>, IContentRepository, IScopedDependency
    {
        public ContentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }


        public IQueryable<Content> GetContentsByPublishedStatus(bool? isPublished, CancellationToken cancellationToken)
        {
            if (isPublished.HasValue)
            {
                return Table.Where(p => p.IsPublished == isPublished).OrderByDescending(x => x.Id);
            }
            else
            {
                return Table.OrderByDescending(x => x.Id);
            }
        }

        public IQueryable<Content> GetLastContents(int top, bool? isPublished, CancellationToken cancellationToken)
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
