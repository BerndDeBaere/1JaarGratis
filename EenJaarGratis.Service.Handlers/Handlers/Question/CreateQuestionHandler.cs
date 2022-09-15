using AutoMapper;
using ClassLibrary1EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Question;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class CreateQuestionHandler : IRequestHandler<CreateQuestionRequest, QuestionResponse>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public CreateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionResponse> Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<QuestionResponse>(await _questionRepository.Insert(Service.Storage.Domain.Question.Create(request.Question, request.Possibilities), cancellationToken));
    }
}