using Common;
using Entities;


namespace Data.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository, IScopedDependency
    {
        public ProjectRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
