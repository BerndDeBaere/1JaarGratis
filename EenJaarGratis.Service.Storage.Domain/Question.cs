using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EenJaarGratis.Service.Storage.Domain;

public class Question:BaseEntity
{
    private Question()
    {
    }

    public string QuestionText { get; set; } = null!;
    public string Answer1 { get; set; }= null!;
    public string Answer2 { get; set; }= null!;
    public string Answer3 { get; set; }= null!;
    public int CorrectAnswer { get; set; }
    
    public int PointsToShare { get; set; }


    public ICollection<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();

    public static Question Create(string question, string answer1, string answer2, string answer3, int correctAnswer) => new()
    {
        QuestionText = question,
        Answer1 = answer1,
        Answer2 = answer2,
        Answer3 = answer3,
        CorrectAnswer =  correctAnswer
    };
}