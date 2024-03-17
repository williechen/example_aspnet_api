
using QADemo.Areas.Auth.Dao;
using QADemo.Bases;

namespace QADemo.Registers;

public class DaoRegister
{
    public static void NewDataAccessObject(IServiceCollection services)
    {
        services.AddScoped<DbUnitOfWork>();
        services.AddScoped<AuthDao>();

    }
}
