using MediatR;
using MediatrSample.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrSample.Application.Queries.GetClientQuery
{
    public class GetClientQueryHandler : IRequestHandler<GetClientQuery, GetClientQueryResult>
    {
        private readonly IClientRepository _clientRepository;

        public GetClientQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetClientQueryResult> Handle(GetClientQuery request, CancellationToken cancellationToken)
            => new GetClientQueryResult(await _clientRepository.Get(request.ClientId));
    }
}
