using QADemo.Domain.Bases;
using QADemo.Domain.Entities;

namespace QADemo.Domain.TableDao;

public class AccountDao : TableDao<Account>
{
    public AccountDao(RustwebdevContext db) : base(db)
    {
    }
}
