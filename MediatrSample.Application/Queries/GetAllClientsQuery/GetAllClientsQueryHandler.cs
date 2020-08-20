using MediatR;
using MediatrSample.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrSample.Application.Queries.GetAllClientsQuery
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, GetAllClientsQueryResult>
    {
        private readonly IClientRepository _clientRepository;

        public GetAllClientsQueryHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<GetAllClientsQueryResult> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var allClients = await _clientRepository.GetAll(i => true);

            return new GetAllClientsQueryResult(allClients);
        }
    }
}
