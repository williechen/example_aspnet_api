using QADemo.Domain.Bases;
using QADemo.Domain.Entities;

namespace QADemo.Domain.DbActions.TableDaos;

public class AccountDao : TableDao<Account>
{
    public AccountDao(RustwebdevContext db) : base(db)
    {
    }
}
