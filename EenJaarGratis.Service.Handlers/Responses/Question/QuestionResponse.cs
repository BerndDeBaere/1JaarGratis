namespace EenJaarGratis.Services.Handlers.Responses.Question;

public class QuestionResponse
{
    public int Id { get; set; }
    public string Question { get; set; } = null!;
    public string Possibilities { get; set; } = null!;
}