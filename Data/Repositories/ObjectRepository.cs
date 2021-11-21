using Common;
using Common.Exceptions;
using Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ObjectRepository : Repository<Entities.Object>, IObjectRepository, IScopedDependency
    {
        public ObjectRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }
        public Task UpdatePublishedStatusAsync(Entities.Object myObject, DateTime? publishedDateTime, CancellationToken cancellationToken)
        {

            if (myObject.IsPublished.HasValue)
            {
                if (myObject.IsPublished.Value)
                {
                    myObject.PublishedDateTime = null;
                }
                else
                {
                    if (publishedDateTime.HasValue)
                    {
                        myObject.PublishedDateTime = publishedDateTime;
                    }
                    else
                    {
                        myObject.PublishedDateTime = DateTime.Now;
                    }
                }

                myObject.IsPublished = !myObject.IsPublished;
                myObject.LastModifiedDateTime = DateTime.Now;

                return UpdateAsync(myObject, cancellationToken);
            }
            throw new BadRequestException(Resources.RepositoryResources.IsPublishedIsNull);
        }
        public Task UpdateActiveStatusAsync(Entities.Object Object, CancellationToken cancellationToken)
        {
            Object.IsActive = !Object.IsActive;
            Object.LastModifiedDateTime = DateTime.Now;

            return UpdateAsync(Object, cancellationToken);
        }
    }
}
