using System.ComponentModel.DataAnnotations;

namespace EenJaarGratis.Service.Storage.Domain;

public class Player: BaseEntity
{
    private Player()
    {
    }

    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    
    public ICollection<QuestionGroup> QuestionGroups { get; set; } = new List<QuestionGroup>();


    public static Player Create(string name, string code) => new()
    {
        Name = name,
        Code = code
    };
}