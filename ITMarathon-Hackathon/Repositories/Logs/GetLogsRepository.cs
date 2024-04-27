using Dapper;
using ITMarathon_Hackathon.DTOs.Logs;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Logs;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Logs
{
    public class GetLogsRepository : IGetLogsRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetLogsRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<GetLogsDTO>> GetLogsAsyncRepo()
        {
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetLogsDTO>("GetLogs", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
