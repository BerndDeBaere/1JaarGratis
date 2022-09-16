using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class GetScoreBoardPlayersHandler : IRequestHandler<GetScoreBoardPlayersRequest, List<ScoreBoardPlayerResponse>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetScoreBoardPlayersHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<ScoreBoardPlayerResponse>> Handle(GetScoreBoardPlayersRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<ScoreBoardPlayerResponse>>(await _playerRepository.GetScoreboard());
    }
}