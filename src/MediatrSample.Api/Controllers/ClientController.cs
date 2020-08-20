using MediatR;
using MediatrSample.Api.Models;
using MediatrSample.Application.Commands.AddClientCommand;
using MediatrSample.Application.Commands.ArchiveClientCommand;
using MediatrSample.Application.Queries.GetAllClientsQuery;
using MediatrSample.Application.Queries.GetClientQuery;
using MediatrSample.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MediatrSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClient(Guid id)
        {
            var result = await _mediator.Send(new GetClientQuery(id));

            return Ok(new ClientDto(result.Client));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _mediator.Send(new GetAllClientsQuery());

            return Ok(result.Clients.Select(i => new ClientDto(i)));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ArchiveClient(Guid id)
        {
            await _mediator.Send(new ArchiveClientCommand(id));

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActivateClient(Guid id)
        {
            await _mediator.Send(new ArchiveClientCommand(id));

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] ClientDto client)
        {
            var result = await _mediator.Send(new AddClientCommand(client.FirstName, client.LastName));
            
            return Ok(result.NewClientId.ToString());
        }
    }
}
