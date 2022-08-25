using EenJaarGratis.Service.Handlers.Responses;
using MediatR;

namespace EenJaarGratis.Service.Handlers.Requests;

public class GetPlayersRequest : IRequest<List<PlayerResponse>>
{
}