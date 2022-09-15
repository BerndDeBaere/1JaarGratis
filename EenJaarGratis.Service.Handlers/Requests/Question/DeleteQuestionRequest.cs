using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Question;

public class DeleteQuestionRequest : IRequest<bool>
{
    public int Id { get; set; }
}