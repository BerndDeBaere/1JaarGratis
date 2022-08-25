namespace EenJaarGratis.Service.Storage.Domain;

public class Player
{
    private Player()
    {
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;

    public static Player Create(string name, string code) => new Player
    {
        Name = name,
        Code = code
    };
}