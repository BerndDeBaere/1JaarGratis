using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Player;

public class CreatePlayerRequest : IRequest<PlayerResponse>
{
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int PointOffset { get; set; }
}