using MediatR;
using MediatrSample.Domain.Entities;
using MediatrSample.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatrSample.Application.Commands.AddClientCommand
{
    public class AddClientCommandHandler : IRequestHandler<AddClientCommand, AddClientCommandResult>
    {
        private readonly IClientRepository _clientRepository;

        public AddClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<AddClientCommandResult> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var newClientId = await _clientRepository.Add(new Client(request.FirstName, request.LastName));
            return new AddClientCommandResult(newClientId);
        }
    }
}
