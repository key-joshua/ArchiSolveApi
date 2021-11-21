using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public interface ICalculatorRepository : IRepository<Calculator>
    {
        IQueryable<Calculator> GetCalculatorsByPublishedStatus(bool? isPublished, CancellationToken cancellationToken);

    }
}