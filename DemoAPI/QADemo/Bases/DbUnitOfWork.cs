using QADemo.Domain.Bases;
using QADemo.Domain.DbActions;
using QADemo.Domain.DbActions.DbExecutes;
using QADemo.Domain.DbActions.TableDaos;

namespace QADemo.Bases;
 public class DbUnitOfWork
{
    private readonly ILogger<DbUnitOfWork> _logger;
    private readonly RustwebdevContext _db;
    // Db Execute
    public IDbExecute dbRawExecute {get; private set;} 
    public IDbExecute dbObjDapper{ get; private set;}
    // Table 
    public AccountDao accountDao{get; private set;}
    public AnswerDao answerDao{get; private set;}
    public QuestionDao questionDao{get; private set;}
    
    public DbUnitOfWork(ILogger<DbUnitOfWork> logger, RustwebdevContext db){
        _logger = logger;
        _db = db;

        dbRawExecute = new DbRawExecute(_logger,_db);
        dbObjDapper = new DbObjDapper(_logger, _db);

        accountDao = new AccountDao(_db);
        answerDao = new AnswerDao(_db);
        questionDao = new QuestionDao(_db);
    }
}
