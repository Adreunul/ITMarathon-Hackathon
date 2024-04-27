using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Infrastructure;
using ITMarathon_Hackathon.Interfaces.Users;
using ITMarathon_Hackathon.Repositories.Users;
using ITMarathon_Hackathon.Repositories.Transactions;
using ITMarathon_Hackathon.Interfaces.Transactions;

namespace ITMarathon_Hackathon
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            //USER
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();

            //TRANSACTION
            services.AddScoped<IMakeTransactionRepository, MakeTransactionRepository>();
            services.AddScoped<IGetTransactionCommissionRepository, GetTransactionCommissionRepository>();

            return services;
        }
    }
}
