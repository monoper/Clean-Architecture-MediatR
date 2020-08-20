using MediatrSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Infrastructure.SqlContext
{
    public class MediatrSampleDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }


        public MediatrSampleDbContext(DbContextOptions<MediatrSampleDbContext> options) : base(options) 
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasKey(i => i.Id);
        }

        //Move to testing context
        protected DbContextOptions<MediatrSampleDbContext> _options { get; }
        private void Seed()
        {
            //Stuff for testing. Clean up later
            using (var context = new MediatrSampleDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var client1 = new Client("AA", "BB");

                context.Clients.AddRange(
                    new Client("AA", "BB"),
                    new Client("CC", "DD"),
                    new Client("EE", "FF"),
                    new Client("GG", "HH"));

                context.SaveChanges();
            }
        }
    }
}
