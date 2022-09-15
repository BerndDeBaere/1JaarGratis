using EenJaarGratis.Service.Storage.Domain;

namespace EenJaarGratis.Service.Storage;

public interface IQuestionGroupRepository : IBaseRepository<QuestionGroup>
{
}

public class QuestionGroupRepository : BaseRepository<QuestionGroup>, IQuestionGroupRepository
{
    public QuestionGroupRepository(Context context) : base(context)
    {
    }
}