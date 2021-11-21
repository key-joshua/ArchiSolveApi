using Common;
using Entities;
//using Common.Exceptions;
//using Common.Utilities;
//using Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LinkRepository : Repository<Link>, ILinkRepository, IScopedDependency
    {
        public LinkRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
