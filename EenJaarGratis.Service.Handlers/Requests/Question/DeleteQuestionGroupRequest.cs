using EenJaarGratis.Services.Handlers.Responses.Question;
using MediatR;

namespace EenJaarGratis.Services.Handlers.Requests.Question;

public class DeleteQuestionGroupRequest : IRequest<QuestionGroupResponse>
{
    public int QuestionId { get; set; }
    public int QuestionGroupId { get; set; }
}