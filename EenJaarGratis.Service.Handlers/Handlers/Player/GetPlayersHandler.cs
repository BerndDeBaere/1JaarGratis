using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class GetPlayersHandler : IRequestHandler<GetPlayersRequest, List<PlayerResponse>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetPlayersHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<PlayerResponse>> Handle(GetPlayersRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<PlayerResponse>>(await _playerRepository.Get(cancellationToken));
    }
}