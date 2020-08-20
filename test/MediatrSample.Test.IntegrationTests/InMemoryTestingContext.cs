using MediatrSample.Infrastructure.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace MediatrSample.Test.IntegrationTests
{
    public abstract class InMemoryTestingContext
    {
        protected DbContextOptions<MediatrSampleDbContext> _options;

        public InMemoryTestingContext(DbContextOptions<MediatrSampleDbContext> options)
        {
            _options = options;
        }

        protected abstract void Seed();
    }
}
