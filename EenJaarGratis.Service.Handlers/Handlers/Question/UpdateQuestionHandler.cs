using AutoMapper;
using ClassLibrary1EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Question;
using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionRequest, QuestionResponse?>
{
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public UpdateQuestionHandler(IQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<QuestionResponse?> Handle(UpdateQuestionRequest request, CancellationToken cancellationToken)
    {
        Service.Storage.Domain.Question? question = await _questionRepository.GetById(request.Id);
        if (question is null)
        {
            return null;
        }
        _mapper.Map(request, question);
        
        return _mapper.Map<QuestionResponse>(await _questionRepository.Update(question, cancellationToken));
    }
}