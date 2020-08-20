using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediatrSample.Application.Commands.AddClientCommand
{
    public class AddClientCommand : IRequest<AddClientCommandResult>
    {

        public AddClientCommand(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
