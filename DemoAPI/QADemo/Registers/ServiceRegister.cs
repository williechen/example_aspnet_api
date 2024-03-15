using QADemo.Areas.Account.Service;
using QADemo.Areas.Answer.Service;
using QADemo.Areas.Auth.Service;
using QADemo.Areas.Question.Service;

namespace QADemo.Registers;

public class ServiceRegister
{

    public static void NewService(IServiceCollection service)
    {

        service.AddScoped<JwtHelpers>();

        service.AddScoped<AccountService>();
        service.AddScoped<AnswerService>();
        service.AddScoped<AuthService>();
        service.AddScoped<QuestionService>();
    }

}
