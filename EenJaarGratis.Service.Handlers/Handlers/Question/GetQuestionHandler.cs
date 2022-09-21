using AutoMapper;
using ClassLibrary1EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Question;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class GetQuestionHandler : IRequestHandler<GetQuestionRequest, List<QuestionResponse>>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<List<QuestionResponse>> Handle(GetQuestionRequest request, CancellationToken cancellationToken)
    {
        List<QuestionResponse>? questions = _mapper.Map<List<QuestionResponse>>(await _questionRepository.Get(cancellationToken));
        int i = 0;
        questions?.ForEach(q => q.Order = i++);
        return questions;
    }
}