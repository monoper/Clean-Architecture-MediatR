using MediatR;
using MediatrSample.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrSample.Application.Commands.ArchiveClientCommand
{
    public class ArchiveClientCommandHandler : AsyncRequestHandler<ArchiveClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public ArchiveClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        protected override async Task Handle(ArchiveClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.ClientId);

            client.Archive();

            await _clientRepository.Update(client);
        }
    }
}
