using Dapper;
using ITMarathon_Hackathon.DTOs.Coins;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Coins;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Coins
{
    public class UserCoinsRepository : IUserCoinsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserCoinsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<UserCoinsDTO>> GetUserCoinsAsyncRepo(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", userId);

            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<UserCoinsDTO>("GetUserCoinsById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
