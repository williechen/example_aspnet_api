using QADemo.Domain.Bases;
using QADemo.Domain.Entities;

namespace QADemo.Domain.TableDao;

public class AnswerDao : TableDao<Answer>
{
    public AnswerDao(RustwebdevContext db) : base(db)
    {
    }
}
