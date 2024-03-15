using QADemo.Areas.Account.Support;
using QADemo.Areas.Answer.Support;
using QADemo.Areas.Auth.Support;
using QADemo.Areas.Question.Support;

namespace QADemo.Registers;

public class SupportRegister
{
    public static void NewService(IServiceCollection services)
    {

        services.AddScoped<JwtHelpers>();

        services.AddScoped<AccountSupport>();
        services.AddScoped<AnswerSupport>();
        services.AddScoped<AuthSupport>();
        services.AddScoped<QuestionSupport>();
    }
}
