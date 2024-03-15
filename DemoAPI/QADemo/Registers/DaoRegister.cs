
using QADemo.Areas.Auth.Dao;

namespace QADemo.Registers;

public class DaoRegister
{
    public static void NewDataAccessObject(IServiceCollection services)
    {
        services.AddScoped<DBRawExecute>();
        services.AddScoped<AuthDao>();

        services.AddScoped<Domain.TableDao.AccountDao>();
        services.AddScoped<Domain.TableDao.AnswerDao>();
        services.AddScoped<Domain.TableDao.QuestionDao>();

    }
}
