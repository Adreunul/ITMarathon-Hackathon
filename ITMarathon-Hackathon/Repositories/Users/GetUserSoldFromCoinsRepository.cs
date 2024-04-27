using Dapper;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Users;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Users
{
    public class GetUserSoldFromCoinsRepository : IGetUserSoldFromCoinsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetUserSoldFromCoinsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<double> GetUserSoldFromCoinsAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);

            parameters.Add("@soldFromCoins", dbType: DbType.Double, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("GetUserSoldFromCoins", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<double>("@soldFromCoins");
            }
        }
    }
}
