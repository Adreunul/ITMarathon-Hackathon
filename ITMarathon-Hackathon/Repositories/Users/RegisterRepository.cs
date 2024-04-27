using Dapper;
using ITMarathon_Hackathon.DTOs.Users;
using ITMarathon_Hackathon.Interfaces;
using ITMarathon_Hackathon.Interfaces.Users;
using System.Data;
using System.Security.Cryptography;
using System.Text;


namespace ITMarathon_Hackathon.Repositories.Users
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public RegisterRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> RegisterUserAsyncRepo(RegisterDTO registerDTO)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@username", registerDTO.username);

            string hashedPassword = HashPassword(registerDTO.password);
            parameters.Add("@password", hashedPassword);

            parameters.Add("@safeword", registerDTO.safeword);
            parameters.Add("@firstname", registerDTO.firstname);
            parameters.Add("@lastname", registerDTO.lastname);
            parameters.Add("@sold", registerDTO.sold);

            parameters.Add("@IdUser", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var connection = _dbConnectionFactory.ConnectToDataBase())
            {
                await connection.ExecuteAsync("UserRegister", parameters, commandType: CommandType.StoredProcedure);
                return parameters.Get<int>("IdUser");
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
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
