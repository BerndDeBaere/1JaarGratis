using ClassLibrary1EenJaarGratis.Service.Storage;
using EenJaarGratis.Service.Storage;
using EenJaarGratis.Services.Handlers.Requests.Player;
using EenJaarGratis.Services.Handlers.Requests.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Handlers.Question;

public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionRequest>
{
    private readonly IQuestionRepository _questionRepository;

    public DeleteQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Unit> Handle(DeleteQuestionRequest request, CancellationToken cancellationToken)
    {
        Service.Storage.Domain.Question? question = await _questionRepository.GetById(request.Id);
        if(question is null)
        {
            throw new KeyNotFoundException($"Vraag met id {request.Id} niet gevonden");
        }
        await _questionRepository.Delete(question, cancellationToken);
        return Unit.Value;
    }
}