using EenJaarGratis.Service.Handlers.Responses;
using MediatR;

namespace EenJaarGratis.Service.Handlers.Requests;

public class DeletePlayerRequest : IRequest<bool>
{
    public int Id { get; set; }
}