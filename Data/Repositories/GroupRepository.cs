using Common;
using Entities;

namespace Data.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository, IScopedDependency
    {
        public GroupRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
