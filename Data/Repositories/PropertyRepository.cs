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
    public class PropertyRepository : Repository<Property>, IPropertyRepository, IScopedDependency
    {
        public PropertyRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
