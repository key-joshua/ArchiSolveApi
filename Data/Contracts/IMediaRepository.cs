using Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IMediaRepository : IRepository<Media>
    {
        public IQueryable<Media> GetByRefrenceId(int refId, ObjectType objectType, MediaType mediaType, SizeType sizeType, CancellationToken cancellationToken);

        public IQueryable<Media> GetObjectMedias(ObjectType objectType, int refId, CancellationToken cancellationToken);

    }
}