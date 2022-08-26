using EenJaarGratis.Service.Handlers.Requests;
using EenJaarGratis.Service.Handlers.Responses;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using MediatR;

namespace EenJaarGratis.Service.Handlers;

public class DeletePlayerHandler : IRequestHandler<DeletePlayerRequest, bool>
{
    private readonly IPlayerRepository _playerRepository;

    public DeletePlayerHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<bool> Handle(DeletePlayerRequest request, CancellationToken cancellationToken)
    {
        Player? player = await _playerRepository.GetById(request.Id);
        if (player is null)
        {
            return false;
        }

        await _playerRepository.Delete(player, cancellationToken);
        return true;
    }
}