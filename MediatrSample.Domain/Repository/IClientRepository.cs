using MediatrSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediatrSample.Domain.Repository
{
    public interface IClientRepository : IRepository<Client, Guid>
    {
    }
}
