using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public interface IPageRepository : IRepository<Page>
    {
        IQueryable<Page> GetPagesByParentId(int parentId, bool? isPublished, CancellationToken cancellationToken);

    }
}