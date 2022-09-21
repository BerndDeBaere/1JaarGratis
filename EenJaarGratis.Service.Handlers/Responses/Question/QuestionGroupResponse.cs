using EenJaarGratis.Services.Handlers.Responses.Player;

namespace EenJaarGratis.Services.Handlers.Responses.Question;

public class QuestionGroupResponse
{
    public int Id { get; set; }
    public List<PlayerResponse> Players { get; set; } = new();
    public int PointsPerPlayer { get; set; }
}