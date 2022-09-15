using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EenJaarGratis.Service.Storage.Domain;

public class QuestionGroup:BaseEntity
{
    private QuestionGroup()
    {
    }

    public Question Question { get; set; } = null!;
    public ICollection<Player> Players { get; set; } = new List<Player>();


    [NotMapped] public int PointsPerUser => Question.PointsToShare / (Players?.Count ?? 1);

    public static QuestionGroup Create(Question question, List<Player> players) => new()
    {
        Question = question,
        Players = players
    };
}