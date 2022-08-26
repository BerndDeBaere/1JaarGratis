using EenJaarGratis.Service.Handlers.Responses;
using MediatR;

namespace EenJaarGratis.Service.Handlers.Requests;

public class UpdatePlayerRequest : IRequest<PlayerResponse?>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
}