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
    public class RoleRepository : Repository<Role>, IRoleRepository, IScopedDependency
    {
        public RoleRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
