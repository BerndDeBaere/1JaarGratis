using EenJaarGratis.Service.Storage.Domain;

namespace EenJaarGratis.Service.Storage;

public interface IQuestionRepository : IBaseRepository<Question, int>
{
}

public class QuestionRepository : BaseRepository<Question, int>, IQuestionRepository
{
    public QuestionRepository(Context context) : base(context)
    {
    }
}