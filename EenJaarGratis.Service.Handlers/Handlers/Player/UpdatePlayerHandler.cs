using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

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
        Service.Storage.Domain.Player? player = await _playerRepository.GetById(request.Id);
        if (player is null)
        {
            return null;
        }
        _mapper.Map(request, player);
        
        return _mapper.Map<PlayerResponse>(await _playerRepository.Update(player, cancellationToken));
    }
}