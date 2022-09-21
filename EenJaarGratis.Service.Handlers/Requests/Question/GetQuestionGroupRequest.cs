using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Question;

public class GetQuestionGroupRequest : IRequest<List<QuestionGroupResponse>>
{
    public int QuestionId { get; set; }
}