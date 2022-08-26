using AutoMapper;
using EenJaarGratis.Service.Handlers.Requests;
using EenJaarGratis.Service.Handlers.Responses;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using MediatR;

namespace EenJaarGratis.Service.Handlers;

public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerRequest, PlayerResponse?>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public UpdatePlayerHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<PlayerResponse?> Handle(UpdatePlayerRequest request, CancellationToken cancellationToken)
    {
        Player? player = await _playerRepository.GetById(request.Id);
        if (player is null)
        {
            return null;
        }
        _mapper.Map(request, player);
        
        return _mapper.Map<PlayerResponse>(await _playerRepository.Update(player, cancellationToken));
    }
}