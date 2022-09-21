using System.Linq.Expressions;
using EenJaarGratis.Service.Storage.Domain;
using Microsoft.EntityFrameworkCore;

namespace EenJaarGratis.Service.Storage;

public interface IQuestionGroupRepository : IBaseRepository<QuestionGroup>
{
    Task<List<QuestionGroup>> GetByQuestion(int questionId, params Expression<Func<QuestionGroup, object>>[] includes);
}

public class QuestionGroupRepository : BaseRepository<QuestionGroup>, IQuestionGroupRepository
{
    public QuestionGroupRepository(Context context) : base(context)
    {
    }

    public async Task<List<QuestionGroup>> GetByQuestion(int questionId, params Expression<Func<QuestionGroup, object>>[] includes)
    {
        IQueryable<QuestionGroup> query = _context.QuestionGroups.Where(qg => qg.Question.Id == questionId);
        includes.ToList().ForEach(i => query = query.Include(i));
        return await query.ToListAsync();
    }
}