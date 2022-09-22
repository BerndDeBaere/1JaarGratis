using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class DeletePlayerHandler : IRequestHandler<DeletePlayerRequest>
{
    private readonly IPlayerRepository _playerRepository;

    public DeletePlayerHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<Unit> Handle(DeletePlayerRequest request, CancellationToken cancellationToken)
    {
        Service.Storage.Domain.Player? player = await _playerRepository.GetById(request.Id);
        if (player is null)
        {
            throw new KeyNotFoundException($"Speler met id {request.Id} niet gevonden");
        }
        await _playerRepository.Delete(player, cancellationToken);
        return Unit.Value;
    }
}