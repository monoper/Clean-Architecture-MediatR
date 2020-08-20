using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Application.Commands.ActivateClientCommand
{
    public class ActivateClientCommand : IRequest
    {
        public ActivateClientCommand(Guid clientId)
        {
            ClientId = clientId;
        }
        public Guid ClientId { get; }
    }
}
