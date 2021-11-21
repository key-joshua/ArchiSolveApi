using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IObjectRepository : IRepository<Entities.Object>
    {
        Task UpdateActiveStatusAsync(Entities.Object Object, CancellationToken cancellationToken);
        Task UpdatePublishedStatusAsync(Entities.Object Object, DateTime? publishedDateTime, CancellationToken cancellationToken);
    }
}