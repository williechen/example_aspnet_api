using QADemo.Domain.Bases;
using QADemo.Domain.Entities;

namespace QADemo.Domain.DbActions.TableDaos;

public class AnswerDao : TableDao<Answer>
{
    public AnswerDao(RustwebdevContext db) : base(db)
    {
    }
}
