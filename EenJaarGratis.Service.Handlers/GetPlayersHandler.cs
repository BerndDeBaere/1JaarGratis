using AutoMapper;
using EenJaarGratis.Service.Handlers.Requests;
using EenJaarGratis.Service.Handlers.Responses;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using MediatR;

namespace EenJaarGratis.Service.Handlers;

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