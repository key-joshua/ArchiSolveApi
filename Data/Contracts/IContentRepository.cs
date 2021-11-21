using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public interface IContentRepository : IRepository<Content>
    {
        IQueryable<Content> GetContentsByPublishedStatus(bool? isPublished, CancellationToken cancellationToken);
        IQueryable<Content> GetLastContents(int top, bool? isPublished, CancellationToken cancellationToken);
    }
}