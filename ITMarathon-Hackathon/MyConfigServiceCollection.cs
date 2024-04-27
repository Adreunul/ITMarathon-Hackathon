using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Infrastructure;
using ITMarathon_Hackathon.Interfaces.Users;
using ITMarathon_Hackathon.Repositories.Users;
using ITMarathon_Hackathon.Repositories.Transactions;
using ITMarathon_Hackathon.Interfaces.Transactions;
using ITMarathon_Hackathon.Interfaces.Coins;
using ITMarathon_Hackathon.Repositories.Coins;
using ITMarathon_Hackathon.Interfaces.Coins;
using ITMarathon_Hackathon.Interfaces.Logs;
using ITMarathon_Hackathon.Repositories.Logs;

namespace ITMarathon_Hackathon
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();

            //USER
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILogOutRepository,  LogOutRepository>();
            services.AddScoped<IResetPasswordRepository, ResetPasswordRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<IAddUserFundsRepository, AddUserFundsRepository>();
            services.AddScoped<IGetUserSoldRepository, GetUserSoldRepository>();
            services.AddScoped<IGetUserSoldFromCoinsRepository, GetUserSoldFromCoinsRepository>();

            //TRANSACTION
            services.AddScoped<IMakeTransactionRepository, MakeTransactionRepository>();
            services.AddScoped<IGetTransactionCommissionRepository, GetTransactionCommissionRepository>();

            //COIN
            services.AddScoped<IUserCoinsRepository, UserCoinsRepository>();
            services.AddScoped<IGetCoinsRepository, GetCoinsRepository>();

            //LOGS
            services.AddScoped<IGetLogsRepository, GetLogsRepository>();

            return services;
        }
    }
}
