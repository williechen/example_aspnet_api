using QADemo.Areas.Account.Support;
using QADemo.Areas.Answer.Support;
using QADemo.Areas.Auth.Support;
using QADemo.Areas.Question.Support;

namespace QADemo.Registers;

public class SupportRegister
{
    public static void NewService(IServiceCollection service)
    {

        service.AddScoped<DBRawExecute>();

        service.AddScoped<AccountSupport>();
        service.AddScoped<AnswerSupport>();
        service.AddScoped<AuthSupport>();
        service.AddScoped<QuestionSupport>();
    }
}
