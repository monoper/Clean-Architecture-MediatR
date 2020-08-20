using MediatrSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatrSample.Infrastructure.SqlContext
{
    public class MediatrSampleDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }


        public MediatrSampleDbContext(DbContextOptions<MediatrSampleDbContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(i => i.Id);
        }
    }
}
