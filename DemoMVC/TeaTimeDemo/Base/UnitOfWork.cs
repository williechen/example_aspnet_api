using System.Transactions;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repositorys;

namespace TeaTimeDemo.Base {
    public class UnitOfWork {
        private readonly ApplicationDbContext _db;
        public QuestionsRepository questionsRepository {get; private set;}
    
        public UnitOfWork(ApplicationDbContext db){

            _db = db;
            questionsRepository = new QuestionsRepository(_db);

        }

        public TransactionScope GetTransaction(){
            TransactionScopeOption scopeOption = TransactionScopeOption.Required;
            TransactionScopeAsyncFlowOption asyncFlowOption = TransactionScopeAsyncFlowOption.Enabled;

            TransactionOptions options = new()
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(120 * TimeSpan.TicksPerSecond)
            };

            return GetTransaction(scopeOption, options, asyncFlowOption);
        }

        public TransactionScope GetTransaction(TransactionScopeOption scopeOption, TransactionOptions options, TransactionScopeAsyncFlowOption asyncFlowOption)
        {
            return new(scopeOption, options, asyncFlowOption);
        }
    }
}