using MediatR;
using System;

namespace MediatrSample.Application.Queries.GetClientQuery
{
    public class GetClientQuery : IRequest<GetClientQueryResult>
    {
        public GetClientQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; }
    }
}
