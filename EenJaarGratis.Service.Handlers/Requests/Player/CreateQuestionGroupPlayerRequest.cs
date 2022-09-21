using EenJaarGratis.Services.Handlers.Responses.Player;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Player;

public class CreateQuestionGroupPlayerRequest : IRequest<PlayerResponse>
{
    public int QuestionGroupId { get; set; }
    public int PlayerId { get; set; }
}