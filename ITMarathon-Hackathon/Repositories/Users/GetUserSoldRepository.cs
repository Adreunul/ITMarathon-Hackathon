using Dapper;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Users;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Users
{
    public class GetUserSoldRepository : IGetUserSoldRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetUserSoldRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<double> GetUserSoldAsyncRepo(int idUser)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", idUser);

            parameters.Add("@sold", dbType: DbType.Double, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("GetUserSold", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<double>("@sold");
            }
        }
    }
}
