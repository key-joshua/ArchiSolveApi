using Common;
using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository, IScopedDependency
    {
        public LoanRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IQueryable<Loan> GetLoansByType(LoanType laonType, bool? isPublished, CancellationToken cancellationToken)
        {
            if (isPublished.HasValue)
            {
                return Table.Where(p => p.IsPublished == isPublished && p.LoanType == laonType);
            }
            else
            {
                return Table.Where(p => p.LoanType == laonType);
            }
        }


    }
}
