using System.ComponentModel.DataAnnotations;

namespace EenJaarGratis.Service.Storage.Domain;

public class Question
{
    private Question()
    {
    }

    [Key] public int Id { get; set; }
    public string QuestionText { get; set; } = null!;
    public string Possibilities { get; set; } = null!;

    public static Question Create(string question, string possibilities) => new()
    {
        QuestionText = question,
        Possibilities = possibilities
    };
}