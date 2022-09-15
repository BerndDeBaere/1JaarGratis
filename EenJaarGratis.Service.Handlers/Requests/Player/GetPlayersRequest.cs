using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Player;

public class GetPlayersRequest : IRequest<List<PlayerResponse>>
{
}