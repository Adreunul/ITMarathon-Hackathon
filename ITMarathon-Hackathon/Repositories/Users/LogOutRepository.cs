using Dapper;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Users;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Users
{
    public class LogOutRepository : ILogOutRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public LogOutRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> LogOutAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@IdUser", idUser);

            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UserLogOut", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@Success");
            }
        }
    }
}
