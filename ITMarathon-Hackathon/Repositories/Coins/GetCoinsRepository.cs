using Dapper;
using ITMarathon_Hackathon.DTOs.Coins;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Coins;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Coins
{
    public class GetCoinsRepository : IGetCoinsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public GetCoinsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<GetCoinsDTO>> GetCoinsAsyncRepo()
        {
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetCoinsDTO>("GetCoins", commandType: CommandType.StoredProcedure); 
                return result;
            }
        }
    }
}
