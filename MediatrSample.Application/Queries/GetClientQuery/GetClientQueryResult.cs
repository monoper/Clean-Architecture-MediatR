using MediatrSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Application.Queries.GetClientQuery
{
    public class GetClientQueryResult
    {
        public GetClientQueryResult(Client client)
        {
            Client = client;
        }
        public Client Client { get; }
    }
}
