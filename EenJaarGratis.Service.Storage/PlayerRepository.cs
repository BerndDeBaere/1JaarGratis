using EenJaarGratis.Service.Storage.Domain;

namespace EenJaarGratis.Service.Storage;

public interface IPlayerRepository : IBaseRepository<Player, int>
{
}

public class PlayerRepository : BaseRepository<Player, int>, IPlayerRepository
{
    public PlayerRepository(Context context) : base(context)
    {
    }
}