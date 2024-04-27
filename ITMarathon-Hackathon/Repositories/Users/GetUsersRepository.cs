using Dapper;
using ITMarathon_Hackathon.DTOs.Users;
using ITMarathon_Hackathon.Interfaces;
using System.Data;

namespace ITMarathon_Hackathon.Repositories.Users
{
    public class GetUsersRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public GetUsersRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }//
        public async Task<IEnumerable<GetUsersDTO>> GetUsersAsyncRepo()
        {
            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                var result = await connection.QueryAsync<GetUsersDTO>("GetUsers", commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
