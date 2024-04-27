using ITMarathon_Hackathon.DTOs;
using ITMarathon_Hackathon.Interfaces;
using System.Security.Cryptography;
using System.Text;
using Dapper;
using System.Data;

namespace ITMarathon_Hackathon.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public LoginRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<int> LoginAsyncRepo(LoginDTO loginDTO)
        {
            var parameters = new DynamicParameters(); 

            parameters.Add("@username", loginDTO.username);
            
            string hashedPassword = HashPassword(loginDTO.password);
            parameters.Add("@password", hashedPassword);

            parameters.Add("@IdUser", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var connection = _connectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UserLogin", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("@IdUser");
            }
        }
        private string HashPassword(string pasword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pasword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    
}
