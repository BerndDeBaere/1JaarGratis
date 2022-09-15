using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IPlayerRepository : IBaseRepository<Player>
{
    Task<List<Player>> GetByIds(List<int> playerIds);
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

    public void Scoreboard()
    {
        // select P.Name, SUM(PointsPerGroup.Points) Points from Players P
        // inner join PlayerQuestionGroup PQG on P.Id = PQG.PlayersId
        //     inner join (
        //     select QG.Id, Q.PointsToShare / count(PQG.PlayersId) as Points from QuestionGroups QG
        // inner join Questions Q on QG.QuestionId = Q.Id
        //     inner join PlayerQuestionGroup PQG on QG.Id = PQG.QuestionGroupsId
        //     Group by QG.Id
        // ) as PointsPerGroup on PQG.QuestionGroupsId = PointsPerGroup.Id
        //     group by PlayersId

    }
}