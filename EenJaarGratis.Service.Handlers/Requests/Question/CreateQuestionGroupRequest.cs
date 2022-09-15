using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Question;

public class CreateQuestionGroupRequest : IRequest<QuestionGroupResponse>
{
    public int QuestionId { get; set; }
    public List<int> PlayerIds { get; set; }= null!;
}