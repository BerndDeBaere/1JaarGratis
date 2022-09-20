namespace EenJaarGratis.Service.Storage.Domain;

public record ScoreBoardPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Points { get; set; }
}