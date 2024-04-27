using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Infrastructure;

namespace ITMarathon_Hackathon
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            return services;
        }
    }
}
