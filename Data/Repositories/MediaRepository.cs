using Common;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MediaRepository : Repository<Media>, IMediaRepository, IScopedDependency
    {
        public MediaRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Media> GetByRefrenceId(int refId, ObjectType objectType, MediaType mediaType, SizeType sizeType, CancellationToken cancellationToken)
        {
            return Table.Where(p => p.ReferenceId == refId && p.ObjectType == objectType && p.MediaType == mediaType && p.SizeType == sizeType); ;
        }

        public IQueryable<Media> GetObjectMedias(ObjectType objectType, int refId, CancellationToken cancellationToken)
        {
                return Table.Where(p => p.ObjectType == objectType && p.ReferenceId == refId);
        }


    }
}
