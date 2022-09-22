using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Player;

public class DeletePlayerRequest : IRequest
{
    public int Id { get; set; }
}