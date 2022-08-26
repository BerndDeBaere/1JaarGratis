using System.ComponentModel.DataAnnotations;

namespace EenJaarGratis.Service.Storage.Domain;

public class Player
{
    private Player()
    {
    }

    [Key] public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public static Player Create(string name, string code) => new()
    {
        Name = name,
        Code = code
    };
}