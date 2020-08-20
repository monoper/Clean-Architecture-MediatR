using MediatrSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Application.Queries.GetAllClientsQuery
{
    public class GetAllClientsQueryResult
    {
        public GetAllClientsQueryResult(List<Client> clients)
        {
            Clients = clients;
        }

        public List<Client> Clients { get; }
    }
}
