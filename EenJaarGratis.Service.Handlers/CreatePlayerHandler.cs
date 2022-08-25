using EenJaarGratis.Service.Handlers.Requests;
using EenJaarGratis.Service.Handlers.Responses;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using MediatR;

namespace EenJaarGratis.Service.Handlers;

public class CreatePlayerHandler : IRequestHandler<CreatePlayerRequest, PlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;

    public CreatePlayerHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<PlayerResponse> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
    {
        var result = await _playerRepository.Insert(Player.Create(request.Name, request.Name), cancellationToken);
        return new PlayerResponse
        {
            Name = result.Name
        };
    }
}