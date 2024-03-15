using QADemo.Domain.Bases;
using QADemo.Domain.Entities;

namespace QADemo.Domain.TableDao;

public class QuestionDao : TableDao<Question>
{
    public QuestionDao(RustwebdevContext db) : base(db)
    {
    }
}
