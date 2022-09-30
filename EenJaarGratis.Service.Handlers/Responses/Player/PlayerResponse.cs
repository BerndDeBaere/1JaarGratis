namespace EenJaarGratis.Services.Handlers.Responses.Player;

public class PlayerResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public int PointOffset { get; set; } 
    public int QuestionCount {get; set; }
}