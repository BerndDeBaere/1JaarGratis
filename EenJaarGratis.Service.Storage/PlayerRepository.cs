using System.Data.Common;
using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IPlayerRepository : IBaseRepository<Player>
{
    Task<List<Player>> GetByIds(List<int> playerIds);
    Task<List<ScoreBoardPlayer>> GetScoreboard();
    Task<Player> GetByCode(string requestCode);
}

public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
{
    public PlayerRepository(Context context) : base(context)
    {
    }

    public async Task<List<Player>> GetByIds(List<int> playerIds)
    {
        List<Player> players = await _context.Players.Where(p => playerIds.Contains(p.Id)).ToListAsync();
        return players;
    }

    public async Task<List<ScoreBoardPlayer>> GetScoreboard()
    {
        List<ScoreBoardPlayer> results = new();
        await using DbConnection connection = _context.Database.GetDbConnection();
        try
        {
            await connection.OpenAsync();
            await using DbCommand command = connection.CreateCommand();
            command.CommandText = ScoreBoardSql;
            await using DbDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                results.Add(new ScoreBoardPlayer
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Points = reader.GetInt64(2)
                });
            }
        }
        finally
        {
            await connection.CloseAsync();
        }


        return results;
    }

    public Task<Player> GetByCode(string requestCode)
    {
        return _context.Players.FirstOrDefaultAsync(p => p.Code == requestCode);
    }

    const string ScoreBoardSql = @"
select P.Id, P.Name, IFNULL(SUM(PointsPerGroup.Points),0) Points
    from Players P

left join PlayerQuestionGroup PQG
    on P.Id = PQG.PlayersId

left join (
    select QG.Id, Q.PointsToShare / count(PQG.PlayersId) as Points from QuestionGroups QG
    inner join Questions Q on QG.QuestionId = Q.Id
    inner join PlayerQuestionGroup PQG on QG.Id = PQG.QuestionGroupsId
    Group by QG.Id
) as PointsPerGroup
    on PQG.QuestionGroupsId = PointsPerGroup.Id
group by P.Id
";
}