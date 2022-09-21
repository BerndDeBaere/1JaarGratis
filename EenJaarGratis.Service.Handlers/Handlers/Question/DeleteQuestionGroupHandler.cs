using AutoMapper;
using ClassLibrary1EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage.Domain;
using EenJaarGratis.Services.Handlers.Requests.Question;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class DeleteQuestionGroupHandler : IRequestHandler<DeleteQuestionGroupRequest, QuestionGroupResponse>
{
    private readonly IMapper _mapper;
    private readonly IQuestionGroupRepository _questionGroupRepository;

    public DeleteQuestionGroupHandler(IMapper mapper, IQuestionGroupRepository questionGroupRepository)
    {
        _mapper = mapper;
        _questionGroupRepository = questionGroupRepository;
    }

    public async Task<QuestionGroupResponse> Handle(DeleteQuestionGroupRequest request, CancellationToken cancellationToken)
    {
        QuestionGroup questionGroup = await _questionGroupRepository.GetById(request.QuestionGroupId);
        await _questionGroupRepository.Delete(questionGroup, cancellationToken);
        return _mapper.Map<QuestionGroupResponse>(questionGroup);
    }
}