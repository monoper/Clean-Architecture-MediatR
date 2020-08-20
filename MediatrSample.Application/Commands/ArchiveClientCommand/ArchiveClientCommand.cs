using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Application.Commands.ArchiveClientCommand
{
    public class ArchiveClientCommand : IRequest
    {
        public ArchiveClientCommand(Guid clientId)
        {
            ClientId = clientId;
        }
        public Guid ClientId { get; }
    }
}
