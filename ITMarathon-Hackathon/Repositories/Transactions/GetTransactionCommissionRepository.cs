using Dapper;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Transactions;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Transactions
{
    public class GetTransactionCommissionRepository : IGetTransactionCommissionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetTransactionCommissionRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<double> GetTransactionCommissionAsyncRepo(float transactionValue)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@transactionValue", transactionValue);

            parameters.Add("@transactionCommission", dbType: DbType.Double, direction: ParameterDirection.Output);
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var result = await connection.ExecuteAsync("GetTransactionCommission", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<double>("@transactionCommission");
            }
        }
    }
}
