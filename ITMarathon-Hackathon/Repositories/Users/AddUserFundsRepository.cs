using Dapper;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.DTOs.Users;
using System.Data;
using ITMarathon_Hackathon.Interfaces.Users;

namespace ITMarathon_Hackathon.Repositories.Users
{
    public class AddUserFundsRepository : IAddUserFundsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        
        public AddUserFundsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> AddUserFundsAsyncRepo(AddUserFundsDTO addUserFundsDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", addUserFundsDTO.IdUser);
            parameters.Add("@fundsAmount", addUserFundsDTO.fundsAmount);

            parameters.Add("@Success", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("AddUserFunds", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("Success");
            }

        }
    }
}
