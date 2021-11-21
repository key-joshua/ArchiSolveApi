using Common;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository, IScopedDependency
    {
        public CommentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Comment> GetCommentsByPublishedStatus(bool? isPublished, CancellationToken cancellationToken)
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

        public IQueryable<Comment> GetLastComments(int top, bool isPublished, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.IsPublished == isPublished).Take(top).OrderByDescending(x => x.Id);
        }


    }
}
