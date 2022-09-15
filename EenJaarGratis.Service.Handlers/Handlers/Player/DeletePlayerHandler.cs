using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class DeletePlayerHandler : IRequestHandler<DeletePlayerRequest, bool>
{
    private readonly IPlayerRepository _playerRepository;

    public DeletePlayerHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<bool> Handle(DeletePlayerRequest request, CancellationToken cancellationToken)
    {
        Service.Storage.Domain.Player? player = await _playerRepository.GetById(request.Id);
        if (player is null)
        {
            return false;
        }
        await _playerRepository.Delete(player, cancellationToken);
        return true;
    }
}