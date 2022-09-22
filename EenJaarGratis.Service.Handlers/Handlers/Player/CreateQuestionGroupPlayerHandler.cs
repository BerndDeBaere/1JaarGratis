using AutoMapper;
using EenJaarGratis.Common;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class CreateQuestionGroupPlayerHandler : IRequestHandler<CreateQuestionGroupPlayerRequest, PlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IQuestionGroupRepository _questionGroupRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public CreateQuestionGroupPlayerHandler(IPlayerRepository playerRepository, IMapper mapper,
        IQuestionGroupRepository questionGroupRepository, IQuestionRepository questionRepository)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
        _questionGroupRepository = questionGroupRepository;
        _questionRepository = questionRepository;
    }

    public async Task<PlayerResponse> Handle(CreateQuestionGroupPlayerRequest request,
        CancellationToken cancellationToken)
    {
        Service.Storage.Domain.Player player = await _playerRepository.GetById(request.PlayerId);
        if (player is null)
        {
            throw new KeyNotFoundException("Speler niet gevonden");
        }

        QuestionGroup questionGroup = await _questionGroupRepository.GetById(request.QuestionGroupId, q => q
            .Include(qg => qg.Players)
            .Include(qg => qg.Question).ThenInclude(q => q.QuestionGroups).ThenInclude(qg2 => qg2.Players));
        if (questionGroup is null)
        {
            throw new KeyNotFoundException("Groep niet gevonden");
        }
        
        if (questionGroup.Question.QuestionGroups.SelectMany(x => x.Players).Any(p => p.Id == player.Id))
        {
            throw new AppException("Speler is al in een groep toegevoegd");
        }
        
        questionGroup.Players.Add(player);
        await _questionGroupRepository.Update(questionGroup, cancellationToken);
        return _mapper.Map<PlayerResponse>(player);
    }
}