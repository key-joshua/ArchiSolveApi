using Entities;
using System.Linq;
using System.Threading;

namespace Data.Repositories
{
    public interface ILoanRepository : IRepository<Loan>
    {
        public IQueryable<Loan> GetLoansByType(LoanType laonType, bool? isPublished, CancellationToken cancellationToken);

    }
}