using Common;
using Entities;


namespace Data.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository, IScopedDependency
    {
        public DocumentRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
