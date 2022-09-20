namespace EenJaarGratis.Services.Handlers.Responses.Question;

public class QuestionResponse
{
    public int Id { get; set; }
    public string Question { get; set; } = null!;
    public string Answer1 { get; set; }= null!;
    public string Answer2 { get; set; }= null!;
    public string Answer3 { get; set; }= null!;
    public int CorrectAnswer { get; set; }}