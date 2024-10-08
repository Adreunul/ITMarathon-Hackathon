﻿using Microsoft.AspNetCore.Connections;
using System.Data;
using System.Data.SqlClient;
using ITMarathon_Hackathon.Interfaces;

namespace ITMarathon_Hackathon.Infrastructure
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        IConfiguration _configuration;
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection ConnectToDataBase()
        {
            var conectionString = _configuration.GetConnectionString("ConnectionString");
            IDbConnection connection = new SqlConnection(conectionString);
            connection.Open();
            return connection;
        }
    }
}
