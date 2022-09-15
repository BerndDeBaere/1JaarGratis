using EenJaarGratis.Service.Storage.Domain;

namespace EenJaarGratis.Service.Storage;

public interface IQuestionRepository : IBaseRepository<Question>
{
}

public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
{
    public QuestionRepository(Context context) : base(context)
    {
    }
}