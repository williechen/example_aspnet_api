using QADemo.Domain.Bases;
using QADemo.Domain.Entities;

namespace QADemo.Domain.DbActions.TableDaos;

public class QuestionDao : TableDao<Question>
{
    public QuestionDao(RustwebdevContext db) : base(db)
    {
    }
}
