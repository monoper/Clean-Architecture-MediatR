using MediatrSample.Domain.Entities;
using MediatrSample.Domain.Repository;
using MediatrSample.Infrastructure.SqlContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MediatrSample.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private MediatrSampleDbContext _context;

        public ClientRepository(MediatrSampleDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Add(Client entity)
        {
            var client = await _context.Clients.AddAsync(entity);
            await _context.SaveChangesAsync();

            return client.Entity.Id;
        }
        public Task<Client> Get(Guid id)
            => _context.Clients.FirstOrDefaultAsync(i => i.Id == id);

        public Task<List<Client>> GetAll(Expression<Func<Client, bool>> predicate)
            => _context.Clients.Where(predicate).ToListAsync();

        public async Task Update(Client entity)
        {
            var foundEntity = await _context.Clients.FirstOrDefaultAsync(i => i.Id == entity.Id);

            if(foundEntity is null)
            {
                throw new ArgumentNullException($"{entity.Id} not found");
            }

            foundEntity.FirstName = entity.FirstName;
            foundEntity.LastName = entity.LastName;

            _context.Clients.Update(foundEntity);
            await _context.SaveChangesAsync();
        }
    }
}
