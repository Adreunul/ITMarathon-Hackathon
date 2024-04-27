using Dapper;
using ITMarathon_Hackathon.DTOs.Transactions;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Transactions;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Transactions
{
    public class MakeTransactionRepository : IMakeTransactionRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public MakeTransactionRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> MakeTransactionAsyncRepo(MakeTransactionDTO makeTransactionDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@IdUser", makeTransactionDTO.IdUser);
            parameters.Add("@IdCoin", makeTransactionDTO.IdCoin);
            parameters.Add("@quantity", makeTransactionDTO.quantity);
            parameters.Add("@coinPriceATM", makeTransactionDTO.coinPriceATM);

            parameters.Add("@IdTransaction", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("MakeTransaction", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("IdTransaction");
            }
        }
    }
}
