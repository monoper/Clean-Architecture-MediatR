using MediatR;
using MediatrSample.Application.Queries.GetAllClientsQuery;

namespace MediatrSample.Application.Queries.GetAllClientsQuery
{
    public class GetAllClientsQuery : IRequest<GetAllClientsQueryResult>
    {
    }
}
