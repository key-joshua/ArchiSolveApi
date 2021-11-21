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
    public class LocationRepository : Repository<Location>, ILocationRepository, IScopedDependency
    {
        public LocationRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
