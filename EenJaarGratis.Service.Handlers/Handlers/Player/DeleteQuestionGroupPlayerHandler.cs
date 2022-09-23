using AutoMapper;
using EenJaarGratis.Common;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Services.Handlers.Handlers.Player;

public class DeleteQuestionGroupPlayerHandler : IRequestHandler<DeleteQuestionGroupPlayerRequest, PlayerResponse>
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IQuestionGroupRepository _questionGroupRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public DeleteQuestionGroupPlayerHandler(IPlayerRepository playerRepository, IMapper mapper,
        IQuestionGroupRepository questionGroupRepository, IQuestionRepository questionRepository)
    {
        _playerRepository = playerRepository;
        _mapper = mapper;
        _questionGroupRepository = questionGroupRepository;
        _questionRepository = questionRepository;
    }

    public async Task<PlayerResponse> Handle(DeleteQuestionGroupPlayerRequest request,
        CancellationToken cancellationToken)
    {

        QuestionGroup questionGroup = await _questionGroupRepository.GetById(request.QuestionGroupId, q => q
            .Include(qg => qg.Players));
        if (questionGroup is null)
        {
            throw new KeyNotFoundException("Groep niet gevonden");
        }

        Service.Storage.Domain.Player? player = questionGroup.Players.FirstOrDefault(p => p.Id == request.PlayerId);
        if (player is null)
        {
            throw new KeyNotFoundException("Speler niet gevonden");
        }

        questionGroup.Players.Remove(player);
        await _questionGroupRepository.Update(questionGroup, cancellationToken);
        return _mapper.Map<PlayerResponse>(player);
    }
}