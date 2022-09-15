using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EenJaarGratis.Service.Storage.Domain;

public class Question:BaseEntity
{
    private Question()
    {
    }

    public string QuestionText { get; set; } = null!;
    public string Possibilities { get; set; } = null!;
    
    public int PointsToShare { get; set; }


    public ICollection<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();

    public static Question Create(string question, string possibilities) => new()
    {
        QuestionText = question,
        Possibilities = possibilities
    };
}