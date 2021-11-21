using Common;
using Entities;


namespace Data.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository, IScopedDependency
    {
        public SectionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
