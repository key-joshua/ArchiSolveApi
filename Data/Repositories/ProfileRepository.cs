using Common;
using Entities;


namespace Data.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository, IScopedDependency
    {
        public ProfileRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
