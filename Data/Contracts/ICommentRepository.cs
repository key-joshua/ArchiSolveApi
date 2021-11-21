using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetCommentsByPublishedStatus(bool? isPublished, CancellationToken cancellationToken);
        IQueryable<Comment> GetLastComments(int top, bool isPublished, CancellationToken cancellationToken);
    }
}