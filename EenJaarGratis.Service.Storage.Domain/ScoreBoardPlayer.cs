namespace EenJaarGratis.Service.Storage.Domain;

public record ScoreBoardPlayer
{
    public string Name { get; set; }
    public long Points { get; set; }
}