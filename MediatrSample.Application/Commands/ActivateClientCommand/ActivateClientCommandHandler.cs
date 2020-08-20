using MediatR;
using MediatrSample.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrSample.Application.Commands.ActivateClientCommand
{
    public class ActivateClientCommandHandler : AsyncRequestHandler<ActivateClientCommand>
    {
        private readonly IClientRepository _clientRepository;

        public ActivateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        protected override async Task Handle(ActivateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.Get(request.ClientId);

            client.Activate();

            await _clientRepository.Update(client);
        }
    }
}
