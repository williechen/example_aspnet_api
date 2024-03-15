using QADemo.Areas.Account.Service;
using QADemo.Areas.Answer.Service;
using QADemo.Areas.Auth.Service;
using QADemo.Areas.Question.Service;
using QADemo.Module.MailMod.Bo;

namespace QADemo.Registers;

public class ServiceRegister
{

    public static void NewService(IServiceCollection services)
    {

        services.AddScoped<AccountService>();
        services.AddScoped<AnswerService>();
        services.AddScoped<AuthService>();
        services.AddScoped<QuestionService>();

        services.AddScoped<MailService>();
    }

}
