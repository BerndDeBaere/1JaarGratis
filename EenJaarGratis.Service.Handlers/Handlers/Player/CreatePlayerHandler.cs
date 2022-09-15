using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class CreatePlayerHandler : IRequestHandler<CreatePlayerRequest, PlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public CreatePlayerHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<PlayerResponse> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<PlayerResponse>(await _playerRepository.Insert(Service.Storage.Domain.Player.Create(request.Name, request.Code), cancellationToken));
    }
}