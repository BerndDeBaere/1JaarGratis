using System.Data.Common;
using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IPlayerRepository : IBaseRepository<Player>
{
    Task<List<Player>> GetByIds(List<int> playerIds);
    Task<List<ScoreBoardPlayer>> GetScoreboard();
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
                    Name = reader.GetString(0),
                    Points = reader.GetInt64(1)
                });
            }
        }
        finally
        {
            await connection.CloseAsync();
        }


        return results;
    }

    const string ScoreBoardSql = @"
        select P.Name, SUM(PointsPerGroup.Points) Points from Players P
        inner join PlayerQuestionGroup PQG on P.Id = PQG.PlayersId
            inner join (
            select QG.Id, Q.PointsToShare / count(PQG.PlayersId) as Points from QuestionGroups QG
        inner join Questions Q on QG.QuestionId = Q.Id
            inner join PlayerQuestionGroup PQG on QG.Id = PQG.QuestionGroupsId
            Group by QG.Id
        ) as PointsPerGroup on PQG.QuestionGroupsId = PointsPerGroup.Id
            group by PlayersId
";
}