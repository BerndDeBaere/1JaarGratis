using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Player;

public class DeletePlayerRequest : IRequest<bool>
{
    public int Id { get; set; }
}