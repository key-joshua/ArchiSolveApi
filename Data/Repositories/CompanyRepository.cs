using Common;
using Entities;


namespace Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository, IScopedDependency
    {
        public CompanyRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
