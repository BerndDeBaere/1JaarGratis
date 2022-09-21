using AutoMapper;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Question;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class GetQuestionGroupHandler : IRequestHandler<GetQuestionGroupRequest, List<QuestionGroupResponse>>
{
    private readonly IMapper _mapper;
    private readonly IQuestionGroupRepository _questionGroupRepository;

    public GetQuestionGroupHandler(IMapper mapper, IQuestionGroupRepository questionGroupRepository)
    {
        _mapper = mapper;
        _questionGroupRepository = questionGroupRepository;
    }

    public async Task<List<QuestionGroupResponse>> Handle(GetQuestionGroupRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<QuestionGroupResponse>>(await _questionGroupRepository.GetByQuestion(request.QuestionId, qg => qg.Players));
    }
}