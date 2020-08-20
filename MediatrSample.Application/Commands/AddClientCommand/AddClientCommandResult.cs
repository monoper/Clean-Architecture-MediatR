using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Application.Commands.AddClientCommand
{
    public class AddClientCommandResult
    {
        public AddClientCommandResult(Guid newClientId)
        {
            NewClientId = newClientId;
        }
        public Guid NewClientId { get; }
    }
}
