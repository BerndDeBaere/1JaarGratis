using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class GetRandomPlayersHandler : IRequestHandler<GetRandomPlayersRequest, List<PlayerResponse>>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IMapper _mapper;

    public GetRandomPlayersHandler(IPlayerRepository playerRepository, IMapper mapper)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
    }

    public async Task<List<PlayerResponse>> Handle(GetRandomPlayersRequest request, CancellationToken cancellationToken)
    {

        var players = await _playerRepository.Get(cancellationToken);
        Random rdm = Random.Shared;
        List<Service.Storage.Domain.Player> list = players.Select(p => new { player = p, order = rdm.Next() })
            .OrderBy(p => p.player.QuestionCount)
            .ThenBy(p => p.order)
            .Select(x => x.player)
            .Take(3)
            .ToList();
        
        list.ForEach(p =>
        {
            p.QuestionCount++;
            _playerRepository.Update(p, cancellationToken);
        });

        return _mapper.Map<List<PlayerResponse>>(list);
    }
}