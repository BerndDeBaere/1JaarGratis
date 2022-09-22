using AutoMapper;
using ClassLibrary1EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests.Question;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class DeleteQuestionGroupHandler : IRequestHandler<DeleteQuestionGroupRequest>
{
    private readonly IMapper _mapper;
    private readonly IQuestionGroupRepository _questionGroupRepository;

    public DeleteQuestionGroupHandler(IMapper mapper, IQuestionGroupRepository questionGroupRepository)
    {
        _mapper = mapper;
        _questionGroupRepository = questionGroupRepository;
    }

    public async Task<Unit> Handle(DeleteQuestionGroupRequest request, CancellationToken cancellationToken)
    {
        QuestionGroup questionGroup = await _questionGroupRepository.GetById(request.QuestionGroupId);
        if (questionGroup is null)
        {
            throw new KeyNotFoundException($"Groep met id {request.QuestionGroupId} niet gevonden");
        }
        await _questionGroupRepository.Delete(questionGroup, cancellationToken);
        return Unit.Value;
    }
}