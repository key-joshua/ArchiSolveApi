using Common;
using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public class CalculatorRepository : Repository<Calculator>, ICalculatorRepository, IScopedDependency
    {
        public CalculatorRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Calculator> GetCalculatorsByPublishedStatus(bool? isPublished, CancellationToken cancellationToken)
        {
            if (isPublished.HasValue)
            {
                return Table.Where(p => p.IsPublished == isPublished);//.OrderByDescending(x => x.Id);
            }
            else
            {
                return Table;
            }
        }

    }
}
