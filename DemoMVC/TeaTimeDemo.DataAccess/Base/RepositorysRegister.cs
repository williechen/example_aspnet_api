using Microsoft.Extensions.DependencyInjection;
using TeaTimeDemo.DataAccess.Repositorys;

namespace TeaTimeDemo.DataAccess.Base
{
    public class RepositorysRegister {

        public static void InjectionService(IServiceCollection services){

            
            services.AddScoped<QuestionsRepository, QuestionsRepository>();


        }

    } 
}