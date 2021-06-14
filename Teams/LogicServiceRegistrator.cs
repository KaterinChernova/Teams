using Teams.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Teams
{
    public static class LogicServiceRegistrator
    {
        public static IServiceCollection RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ITeamService, TeamService>();

            return serviceCollection;
        }
    }
}
