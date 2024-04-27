﻿using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Infrastructure;
using ITMarathon_Hackathon.Interfaces.Users;
using ITMarathon_Hackathon.Repositories.Users;

namespace ITMarathon_Hackathon
{
    public static class MyConfigServiceCollection
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IResetPasswordRepository, ResetPasswordRepository>();
            return services;
        }
    }
}
