using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class CreateQuestionGroupPlayerHandler : IRequestHandler<CreateQuestionGroupPlayerRequest, PlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IQuestionGroupRepository _questionGroupRepository;
    private readonly IMapper _mapper;

    public CreateQuestionGroupPlayerHandler(IPlayerRepository playerRepository, IMapper mapper, IQuestionGroupRepository questionGroupRepository)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
        _questionGroupRepository = questionGroupRepository;
    }

    public async Task<PlayerResponse> Handle(CreateQuestionGroupPlayerRequest request, CancellationToken cancellationToken)
    {
        Service.Storage.Domain.Player player = await _playerRepository.GetById(request.PlayerId);
        QuestionGroup questionGroup = await _questionGroupRepository.GetById(request.QuestionGroupId);
        questionGroup.Players.Add(player);
        await _questionGroupRepository.Update(questionGroup, cancellationToken);
        return _mapper.Map<PlayerResponse>(player);
    }
}